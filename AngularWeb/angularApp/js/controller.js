﻿angular.module('app.controllers', ['app.services']).controller('channelCtrl', function ($scope, channelService) {
    debugger;
    $scope.channels = channelService.getList();
}).
controller('projectCtrl', function ($scope, projectService) {
    $scope.projects = projectService.getList();
});