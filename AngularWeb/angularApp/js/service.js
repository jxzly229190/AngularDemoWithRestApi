angular.module('app.services', ['restangular'])
    .factory('channelService', ['Restangular', function (Restangular) {  
        var channel = Restangular.all('values');
        return {
            getList: function () {
                return channel.getList().$object;
            }
        };
    }])
    .service("projectService", function (Restangular) {
        var projects = Restangular.all('voteprojects');
        return {
            getList: function () {
                return projects.getList().$object;
            },
            one: function (id) {
                return projects.one(id).$object;
            },
            post: function (project) {
                return projects.post(project);
            },
            put: function (id,project) {
                return projects.one(id).put(project);
            }
        }
    });