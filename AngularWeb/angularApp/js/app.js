﻿
var app = angular.module('app', ['ui.router', 'restangular', 'app.services', 'app.controllers']);

app.config(function ($stateProvider) {
    $stateProvider.state('channel', {
        url: "channel",
        abtract: true,
        template: "<div ui-view><h2>Channel Home</h2></div>"
    }).state('channel.add', {
        url: "/add",
        templateUrl: "views/channel/add.html"
    }).state('channel.edit', {
        url: "/edit",
        templateUrl: "views/channel/edit.html"
    }).state('channel.list', {
        url: "/lists",
        templateUrl: "views/channel/list.html",
        controller: 'channelCtrl'
    }).state('error', {
        url: '/error',
        templateUrl: "views/share/error.html"
    });
})
    .config(function (RestangularProvider) {
    RestangularProvider.setBaseUrl('/api');
    })
    //config rest angular in gloabe
    .run(function ($rootScope, $location, Restangular) {
        Restangular.setErrorInterceptor(function (response, deferred, responseHandler) {
            switch (response.status) {
                case 401:
                    $rootScope.$broadcast("unauth", "Session lost");
                    break;
                case 404:
                    $rootScope.$broadcast("httperror", "Not found.");
                    break;
                case 408:
                    $rootScope.$broadcast("httperror", "Timeout.");
                    break;
                case 400:
                    $rootScope.$broadcast("httperror", "Bad request.");
                    break;
                default:
                    $rootScope.$broadcast("httperror", "Request error.");
            }
            return false; // 停止promise链
        });

        /*
        Restangular.addResponseInterceptor(function (data, operation, what, url, response, deferred) {
            //处理自定义错误信息
            if (data.state == 0) {
                return data.data;
            } else if (data.state == 401) {
                $rootScope.$broadcast("authlost", data.msg);
            } else {
                $rootScope.$broadcast("custerror", data.msg);
            }
            
            return null;
        });
        */

        //事件处理
        $rootScope.$on("unauth", function (event, args) {
            alert("The session has been lost, you need login again.");
            $location.path('/login');
            event.preventDefault();
        });

        $rootScope.$on("httperror", function (event, args) {
            if (args != null) {
                alert(args);
            } else {
                $location.path('error');
            }
            event.preventDefault();
        });
    })
    .controller("mainCtrl", function ($scope, projectService) {
        $scope.msg = "Angular Demo";
        $scope.projects = projectService.getList();
    });