(function coreContainer(window) {
    'use strict';
    window.core = new Core();

    function Core() {

        this.PutDigitalProfile = function (data, callback) {
            if (!applyValidation(data)) {
                return {
                    success: false,
                    message: 'Validation failed!'
                };
            }
            window.dal.ajaxPutDigitalProfile(data, function () {
                callback();
            });
        };

        function applyValidation(data) {
            data.userName = data.userName.toLower();
            data.favouriteSport = parseInt(data.favouriteSport);
        };

        (function init() {

        })();
        
    }
})(window);