(function (window) {
    'use strict';
    window.dal = new Dal();

    function Dal() {
        this.ajaxPutClient = function (data, callback) {
            $.ajax({
                cache: false,
                type: 'POST',
                url: '/DataCapture/DataCaptureHandler.ashx',
                dataType: 'text',
                data: JSON.stringify(window.store.data)
            }).done(function (data) {
                if (callback) {
                    callback();
                }
            });
        };
    }
    
    
})(window);