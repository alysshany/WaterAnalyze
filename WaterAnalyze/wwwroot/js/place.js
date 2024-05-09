var myMap;

function start(x, y) {
    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(map(x,y));
}

function deleteMap() {
    // Дождёмся загрузки API и готовности DOM.
    myMap.destroy();
}

function map(x, y) {
    myMap = new ymaps.Map('map', {
        center: [x, y], 
        zoom: 10
    }, {
        searchControlProvider: 'yandex#search'
    });

    myGeoObject = new ymaps.GeoObject({
        geometry: {
            type: "Point",
            coordinates: [x, y]
        },
        properties: {
            // Контент метки.
        }
    });

    myMap.geoObjects
        .add(myGeoObject)
}