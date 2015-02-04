angular.module('app.services', ['restangular'])
.factory('channelService', ['Restangular', function (Restangular) {

    var restAngular = Restangular.withConfig(function (Configurer) {
        Configurer.setBaseUrl('/api');
    });

    var channel = restAngular.all('values');
    return {
        getList: function () {
            return channel.getList().$object;
        }
    };
}]);