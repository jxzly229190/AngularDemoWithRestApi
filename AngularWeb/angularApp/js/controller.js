angular.module('app.controllers', ['app.services']).controller('channelCtrl', function ($scope, channelService) {
    debugger;
    $scope.channels = channelService.getList();
}).
controller('votesCtrl', function ($scope, $stateParams, projectService, voteItemService) {
    $scope.projectName = $stateParams.pn;

    $scope.votes = voteItemService.getList($stateParams.pid);
    $scope.project = projectService.one($stateParams.pid);

    $scope.toggleSelect = function (voteItem) {
        voteItem.IsSelected = !voteItem.IsSelected;
    }
});