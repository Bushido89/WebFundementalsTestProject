(function (window) {

    var store = window.store();

    window.view = new View();

    function View() {

        this.onClickRefreshData = function (trustCache) {
            store.getFlatVehicleManufacturers
        };

        (function init() {

            var ulElem = document.getElementById('someMenu');
            var newLi = document.createElement("li");
            newLi.innerHTML = 'SomeTest';
            ulElem.appendChild(newLi);

            
        })();
    }
})(window);
