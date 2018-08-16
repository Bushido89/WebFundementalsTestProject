(function dalContainer(window) {
    'use strict';
    window.dal = new Dal();

    function Dal() {
        this.ajaxPutDigitalProfile = function (data, callback) {
            $.ajax({
                cache: false,
                type: 'POST',
                url: '/DocumentSynthesis/DocumentSynthesis.ashx',
                dataType: 'text',
                data: JSON.stringify(window.store.data)
            }).done(function (data) {
                if (callback) {
                    callback();
                }
            });
        };
        (function init() {

        })();
    }
})(window);