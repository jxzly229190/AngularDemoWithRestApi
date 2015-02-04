
var app = angular.module('app', ['ui.router','restangular', 'app.services', 'app.controllers']);

app.config(function($stateProvider) {
    $stateProvider.state('channel', {
        url: "channel",
        abtract: true,
        template: "<div ui-view></div>"
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
        url:'/error',
        templateUrl: "views/share/error.html",
        controller: 'channelCtrl'
    });
})
    //config rest angular in gloabe
    .run(function ($location, Restangular) {
        Restangular.setErrorInterceptor(function (resp) {
            $location.path('error');
            return false; // 停止promise链
        });
    })
    .controller("mainCtrl", function ($scope) {
    $scope.msg = "Angular Demo";
});