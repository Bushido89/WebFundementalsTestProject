(function coreContainer(window) {
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
            return true;
        };

        (function init() {

        })();
        
    }
})(window);