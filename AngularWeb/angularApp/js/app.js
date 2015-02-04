
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
    });
}).controller("mainCtrl", function($scope) {
    $scope.msg = "Angular Demo";
});