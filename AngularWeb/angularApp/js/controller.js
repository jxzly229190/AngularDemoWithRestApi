angular.module('app.controllers', ['app.services']).controller('channelCtrl', function ($scope, channelService) {
    debugger;
    $scope.channels = channelService.getList();
}).
controller('projectCtrl', function ($scope, $stateParams, projectService, voteItemService) {
    $scope.project = projectService.one($stateParams.pid);

    $scope.votes = voteItemService.getList($stateParams.pid);

    $scope.addVoteItem= function(voteItem) {
        ;
    }
});