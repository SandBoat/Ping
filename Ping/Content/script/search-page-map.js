// 百度地图API功能
function G(id) {
    return document.getElementById(id);
}

var map = new BMap.Map("l-map");
var myCity = new BMap.LocalCity();
var cityname;
myCity.get(mylocate);

function mylocate(result) {
    map.centerAndZoom(result.center, 12);
    cityname = result.name;
}

var ac = new BMap.Autocomplete( //建立一个自动完成的对象
    {
        "input": "suggestId1",
        "location": map
    });
var ac2 = new BMap.Autocomplete( //建立一个自动完成的对象
    {
        "input": "suggestId2",
        "location": map
    });

function onhighlight_fun(e) {
    var str = "";
    var _value = e.fromitem.value;
    var value = "";
    if (e.fromitem.index > -1) {
        value = _value.province + _value.city + _value.district + _value.street + _value.business;
    }
    str = "FromItem<br />index = " + e.fromitem.index + "<br />value = " + value;

    value = "";
    if (e.toitem.index > -1) {
        _value = e.toitem.value;
        value = _value.province + _value.city + _value.district + _value.street + _value.business;
    }
    str += "<br />ToItem<br />index = " + e.toitem.index + "<br />value = " + value;
    G("searchResultPanel").innerHTML = str;
}

function onconfirm_fun(e) {
    var _value = e.item.value;
    myValue = _value.province + _value.city + _value.district + _value.street + _value.business;
    G("searchResultPanel").innerHTML = "onconfirm<br />index = " + e.item.index + "<br />myValue = " + myValue;

    setPlace();
}

ac.addEventListener("onhighlight", function (e) { onhighlight_fun(e); });
ac2.addEventListener("onhighlight", function (e) { onhighlight_fun(e); });

var myValue;
ac.addEventListener("onconfirm", function (e) { onconfirm_fun(e); });
ac2.addEventListener("onconfirm", function (e) { onconfirm_fun(e); });

function setPlace() {
    map.clearOverlays(); //清除地图上所有覆盖物
    function myFun() {
        var pp = local.getResults().getPoi(0).point; //获取第一个智能搜索的结果
        map.centerAndZoom(pp, 18);
        map.addOverlay(new BMap.Marker(pp)); //添加标注
    }
    var local = new BMap.LocalSearch(map, { //智能搜索
        onSearchComplete: myFun
    });
    local.search(myValue);
}

var releaseBtn = document.getElementById("search");
var searchFomr = document.getElementById("searchForm");
var getPoint_count = 0;

function findPos(posName, posxStr, posyStr) {
    var myGeo = new BMap.Geocoder();
    var posx = document.getElementById(posxStr);
    var posy = document.getElementById(posyStr);

    myGeo.getPoint(posName, function (point) {
        if (point) {
            posx.value = point.lng;
            posy.value = point.lat;

            getPoint_count--;
            if (getPoint_count == 0) {
                searchFomr.submit();
            }
            // console.log(posx.value);
            // console.log(posy.value);
        }
    }, cityname);
}

releaseBtn.onclick = function () {
    getPoint_count = 2;
    findPos(suggestId1.value, "start_x", "start_y");
    findPos(suggestId2.value, "end_x", "end_y");
}
