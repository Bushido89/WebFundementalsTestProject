(function (window) {
    'use strict';
    window.dal = new DAL();

    function DAL() {
        this.ajaxGetVehicleManufacturers = function (callback) {
            $.ajax({
                cache: false,
                type: 'GET',
                url: 'http://localhost:50076/Generic/CarRentalInformation.ashx?req=GetVehicleManufacturers',
            }).done(function (data) {
                if (callback) {
                    callback(data);
                }
            });
        };

        this.ajaxGetVehicleModels = function (vehicleManufacturerlId, callback) {
            $.ajax({
                cache: false,
                type: 'GET',
                url: 'http://localhost:50076/Generic/CarRentalInformation.ashx?req=GetVehicleModels',
                data: {
                    pVehicleManufacturerId: vehicleManufacturerlId
                }
            }).done(function (data) {
                if (callback) {
                    callback(data);
                }
            });
        };
    }
})(window);