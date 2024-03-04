var myMap;

function startmap() {
    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(init);
}

//ymaps.ready(function () {
//    startmap();
//    startAddingObjects();
//});

function init() {

    myMap = new ymaps.Map('map', {
        // При инициализации карты обязательно нужно указать
        // её центр и коэффициент масштабирования.
        center: [55.757496, 52.053939], // Москва
        zoom: 10
    }, {
        searchControlProvider: 'yandex#search'
    });

}

function startAddingObjects(x, y) {
    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(mapBuild(x, y));
}

function mapBuild(x, y) {

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

