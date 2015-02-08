angular.module('app.controllers', ['app.services']).controller('channelCtrl', function ($scope, channelService) {
    debugger;
    $scope.channels = channelService.getList();
}).
controller('votesCtrl', function ($scope, $stateParams, projectService, voteItemService) {
    $scope.isChanged = false;
    $scope.projectName = $stateParams.pn;

    $scope.votes = voteItemService.getList($stateParams.pid);
    $scope.project = projectService.one($stateParams.pid);

    $scope.toggleSelect = function(voteItem) {
        voteItem.IsSelected = !voteItem.IsSelected;

        if (voteItem.IsSelected != voteItem.PreSelected) {
            $scope.isChanged = true;
            return false;
        }

        for (var i = 0; i < $scope.votes.length; i++) {
            if ($scope.votes[i].IsSelected != $scope.votes[i].PreSelected) {
                $scope.isChanged = true;
                return false;
            }
        }

        $scope.isChanged = false;
    };

    $scope.showDetail = function(item, $event) {
        item.showDetail = !item.showDetail;
        $event.stopPropagation();
    };
});