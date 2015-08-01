(function () {
    'use strict';

    angular
        .module('app')
        .factory('attendeeService', attendeeService);

    attendeeService.$inject = ['$http', '$q'];

    var attendees = null;
    function attendeeService($http, $q) {
        var baseUrl = "";
        var service = {
            createAttendee: createAttendee,
            formatAvatars: formatAvatars,
            getAll: getAll,
            getById: getById,
            save: save,
            updateAttendee: updateAttendee,
        };

        return service;

        function getAll() {
            if (attendees !== null)
                return $q.when(attendees);


            return $http.get(baseUrl + 'api/Attendees')
                    .then(function (result) {
                        attendees = result.data;
                        _.map(attendees, function (attendee) {
                            return formatAvatars(attendee);
                        });
                        return result.data;
                    });
        }

        function getById(id) {
            return $http.get(baseUrl + 'api/Attendees/' + id)
                    .then(function (result) {
                        var attendee = result.data;
                        formatAvatars(attendee);
                        return attendee;
                    });
        }

        function formatAvatars(attendee) {
            if (attendee.avatar != null) {
                attendee.avatar.largeImageUrl = baseUrl + attendee.avatar.largeImageUrl;
                attendee.avatar.smallImageUrl = baseUrl + attendee.avatar.smallImageUrl;
            }
            attendee.genericImageUrl = baseUrl + "api/Generic/" + attendee.person.gender + "/Avatar";
            return attendee;
        }

        function createAttendee(attendee) {
            return $http.post(baseUrl + 'api/Attendees/', attendee)
                    .then(function (result) {
                        updateOrReplaceAttendee(result.data);
                        return result.data;
                    });
        }

        function save(attendee) {
            if (angular.isDefined(attendee) === false || attendee === null) {
                return $q.reject("Attendee data missing");
            }

            if (attendee.id > 0)
                return updateAttendee(attendee);

            return createAttendee(attendee);
        }

        function updateAttendee(attendee) {
            var id = attendee.id;
            return $http.put(baseUrl + 'api/Attendees/' + id, attendee)
                    .then(function (result) {
                        updateOrReplaceAttendee(result.data);
                        return result.data;
                    });
        }

        //#region Internal Methods

        function updateOrReplaceAttendee(attendee) {
            var index = -1;

            if (attendees === null) {
                attendees = [];
            }

            for (var i = 0; i < attendees.length; i++) {
                if (attendees[i].id === attendee.id) {
                    index = i;
                    break;
                }
            }

            if (index !== -1) {
                attendees.splice(index, 1);
            }
            attendees.push(attendee);

        }
    }
})();