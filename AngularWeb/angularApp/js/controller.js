angular.module('app.controllers', ['app.services']).controller('channelCtrl', function ($scope, channelService) {
    debugger;
    $scope.channels = channelService.getList(); //[{ name: 'faf' }, { name: 'faf' }, { name: 'fasdf' }, { name: 'fasdf' }];
});