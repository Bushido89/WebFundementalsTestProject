(function (window) {
    'use strict';

    window.view = this;
    var niRegEx = '^([a-zA-Z]){2}( )?([0-9]){2}( )?([0-9]){2}( )?([0-9]){2}( )?([a-zA-Z]){1}?$';
    var emailRegEx = '/\S+@\S+\.\S+/';
    var picker = new Pikaday({
        field: document.getElementById('DateOfBirthTxt'),
        firstDay: 1,
        minDate: new Date(1900, 1, 1),
        maxDate: new Date(2020, 12, 31),
        yearRange: [2000, 2020],
        format: 'DD/MM/YYYY'
    });

    // <Region> Control binds
    var self = this;
    var store = window.store;
    var doc = window.document;
    var submitButton = doc.getElementById('SubmitButton');
    var NINumberTxt = doc.getElementById('NINumberTxt');
    var EmailAddressTxt = doc.getElementById('EmailAddressTxt');
    // </Region>

    function submitEventDelegate() {
        // Apply validation
        if (!checkValidation()) {
            alert('Some meaningful error here!');
            return false;
        }

        window.dal.ajaxPutClient(window.store, function () {
            // Some cool callback stuff
        });

        function checkValidation() {
            // Test validation
            var validationPassed = true;
            if (!NINumberTxt.value.match(niRegEx)) {
                return false;
            }
            if (EmailAddressTxt.value.match(emailRegEx)) {
                return false;
            }
            return true;
        };
    };

    (function init() {
        //Assign events
        submitButton.onclick = submitEventDelegate;
        $.each($('input[type = text]'), function updateStoreFromTextInputs() {
            this.onchange = function () {
                var propName = this.id.substring(0, this.id.length - 3);
                store["".toCamelCase(propName)] = this.value;
            };
        });
    })();
})(window);