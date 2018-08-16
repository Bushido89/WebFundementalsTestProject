(function viewContainer(window) {
    window.view = new View();
    var store = window.store;


    function View() {
        var submitButton = document.getElementById('submitButton');
        var reader = new FileReader();

        function submitEventDelegate() {
            alert('submitHit');
        };

        function onSimpleControlChangeDelegate(event) {
            window.store.data[this.id] = this.value;
        };

        function onMediaControlChangeDelegate(event) {
            window.store.data[this.id].fileData = this.files[0];
        };

        function onReaderLoadDelegate(event) {
            var x = event;
        };

        (function init() {
            //Assign events
            submitButton.onclick = submitEventDelegate;
            var simpleControls = document.getElementsByClassName('form-control');
            for (let item of simpleControls) {
                item.onchange = onSimpleControlChangeDelegate;
                item.dispatchEvent(new Event('change'));
            }

            var mediaControls = document.getElementsByClassName('form-control-media');
            for (let item of mediaControls) {
                window.store.data[item.id] = {
                    relativePath: item.getAttribute('data-rel-path'),
                    fileData: null
                };
                item.onchange = onMediaControlChangeDelegate;
            }

            reader.onload = onReaderLoadDelegate;
        })();
    }
})(window);