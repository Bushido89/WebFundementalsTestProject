(function (window) {
    'use strict';
    window.store = new Store();
    var dal = window.dal;

    function Store() {
        this.getFlatVehicleManufacturers = function (trustCache) {
            if (!trustCache || !data.vehicleManufacturers) {
                dal.getVehicleManufacturers(function (data) {
                    data.vehicleManufacturers = data;
                    return data.vehicleManufacturers;
                });
            }
        }

        this.getFlatVehicleModels = function (Id, trustCache) {
            var vehicleManufacturer = data.vehicleManufacturers.filter(x => x.Id = Id)[0];
            if (!trustCache || !vehicleManufacturer.vehicleModels) {
                dal.getVehicleModels(function (data) {
                    vehicleManufacturer.vehicleModels = data;
                    return vehicleManufacturer.vehicleModels;
                });
            }
        }

        var data = {

        };

        (function init() {

        });
    }
})(window);