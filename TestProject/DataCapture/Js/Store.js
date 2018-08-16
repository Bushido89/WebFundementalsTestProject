(function (window) {
    'use strict';
    window.store = new Store();
    function Store() {
        this.data = {
            forename: '',
            middleName: '',
            surname: '',
            dateOfBirth: new Date(),
            niNumber: '',
            addressLineOne: '',
            addressLineTwo: '',
            addressLineThree: '',
            addressLineFour: '',
            EmailAdress: '',
            photographRef: ''
        };
    }
})(window);