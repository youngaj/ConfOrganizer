(function () {
    'use strict';

    angular
        .module('app')
        .controller('AttendeeSignUpCntrl', AttendeeSignUpCntrl);

    AttendeeSignUpCntrl.$inject = ['attendeeService'];

    function AttendeeSignUpCntrl(attendeeService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'AttendeeSignUpCntrl';
        vm.register = register;

        activate();

        function activate() { }

        function register(attendee) {
            console.log("Registration called");
            return attendeeService.save(attendee).then(function (result) {
                console.log("Registration complete");
                console.log(result);
            }, function (errorResponse){
                console.log("Registration error ", errorResponse);
            });

        }
    }
})();
