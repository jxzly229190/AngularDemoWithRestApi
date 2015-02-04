angular.module('app.controllers', ['app.services']).controller('channelCtrl', function ($scope, channelService) {
    $scope.channels = channelService.getList(); 
});