var myMap;
var myCircle;
var circles = new Array();

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

function startAddingObjects(x, y, title, hardness, sulfat, chloride, calcium, gidrocarbonat, oil, magnesium, acidityIndex) {
    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(mapBuild(x, y, title, hardness, sulfat, chloride, calcium, gidrocarbonat, oil, magnesium, acidityIndex));
}

function startAddingBaloon(x, y) {
    // Дождёмся загрузки API и готовности DOM.
    ymaps.ready(baloonBuild(x, y));
}

function deleteGeo() {
    // Дождёмся загрузки API и готовности DOM.
    circles.forEach(element => {
        myMap.geoObjects.remove(element);
    });
    
}

function baloonBuild(x, y) {

    myCircle = new ymaps.Circle([
        // Координаты центра круга.
        [x, y],
        // Радиус круга в метрах.
        300
    ], {
    }, {
        // Задаем опции круга.
        // Включаем возможность перетаскивания круга.
        draggable: false,
        // Цвет заливки.
        // Последний байт (77) определяет прозрачность.
        // Прозрачность заливки также можно задать используя опцию "fillOpacity".
        fillColor: "#DB709377",
        // Цвет обводки.
        strokeColor: "#990066",
        // Прозрачность обводки.
        strokeOpacity: 0.8,
        // Ширина обводки в пикселях.
        strokeWidth: 5
    });

    // Добавляем круг на карту.
    myMap.geoObjects.add(myCircle);
    circles.push(myCircle);
    
}

function mapBuild(x, y, title, hardness, sulfat, chloride, calcium, gidrocarbonat, oil, magnesium, acidityIndex) {

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
    })
    

    myMap.geoObjects
        .add(myGeoObject)
        .add(new ymaps.Placemark([x, y], {
            balloonContentHeader: title,
            balloonContentBody: [
                hardness,
                '<br/>',
                sulfat,
                '<br/>',
                chloride,
                '<br/>',
                calcium,
                '<br/>',
                gidrocarbonat,
                '<br/>',
                oil,
                '<br/>',
                magnesium,
                '<br/>',
                acidityIndex,
                '<br/>',
                chloride].join(''),
        }, {
            preset: 'islands#icon',
            iconColor: '#0095b6'
        }))
}

