(function viewContainer(window) {
    window.view = new View();
    var store = window.store;


    function View() {
        var submitButton = document.getElementById('submitButton');
        var imageDiv = document.getElementById('imgFavouriteAnimal');
        var audioClipDiv = document.getElementById('sndAudioClip');

        function submitEventDelegate() {
            window.core.PutDigitalProfile(store.data, function () {
                //Put something prettier here
                alert('File successfully uploaded!');
            });
        };

        function onSimpleControlChangeDelegate(event) {
            window.store.data[this.id] = this.value;
        };

        function onMediaControlChangeDelegate(event) {
            window.store.data[this.id].fileMetaData = this.files[0];
            window.store.data[this.id].fileReader.readAsBinaryString(this.files[0]);
        };

        function onReaderLoadDelegate(event) {
            this.parent.fileData = event.currentTarget.result;
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
                    fileReader: null,
                    fileMetaData: null
                };
                item.onchange = onMediaControlChangeDelegate;
                window.store.data[item.id].fileReader = new FileReader();
                window.store.data[item.id].fileReader.parent = window.store.data[item.id];
                window.store.data[item.id].fileReader.onload = onReaderLoadDelegate;
            }
        })();
    }
})(window);