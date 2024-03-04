var myMap;

function start(x, y) {
    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(map(x,y));
}

function map(x, y) {
    myMap = new ymaps.Map('map', {
        // При инициализации карты обязательно нужно указать
        // её центр и коэффициент масштабирования.
        center: [x, y], // Москва
        zoom: 10
    }, {
        searchControlProvider: 'yandex#search'
    });

    myGeoObject = new ymaps.GeoObject({
        // Описание геометрии.
        geometry: {
            type: "Point",
            coordinates: [x, y]
        },
        // Свойства.
        properties: {
            // Контент метки.
            //iconContent: '',
            //hintContent: 'Ну давай уже тащи'
        }
    });

    myMap.geoObjects
        .add(myGeoObject)
}