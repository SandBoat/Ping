nearStart = document.getElementById("near-start");
nearEnd = document.getElementById("near-end");
start_x = document.getElementById("start_x").childNodes[0].data;
start_y = document.getElementById("start_y").childNodes[0].data;
end_x = document.getElementById("end_x").childNodes[0].data;
end_y = document.getElementById("end_y").childNodes[0].data;
date = document.getElementById("date").childNodes[0].data;
start_times = 1000;
end_times = 1000;

var url = "start_x=" + start_x + "&&start_y=" + start_y;
url = url + "&&end_x=" + end_x + "&&end_y=" + end_y;


function getHTTPObject() {
    if (typeof XMLHttpRequest == "undefined") {
        XMLHttpRequest = function () {
            try { return new ActiveXObject("Msxml2.XMLHTTP.6.0"); }
            catch (e) { }
            try { return new ActiveXObject("Msxml2.XMLHTTP.3.0"); }
            catch (e) { }
            try { return new ActiveXObject("Msxml2.XMLHTTP"); }
            catch (e) { }
            return false;
        }
    }
    return new XMLHttpRequest();
}

function getNewContent(curUrl, pos) {
    var request = getHTTPObject();
    if (request) {
        request.open("GET", curUrl, true);
        request.onreadystatechange = function () {
            if (request.readyState == 4) {
                var txt = request.responseText;
                var places = txt.split("|");
                var len = places.length;
                var posNode = document.getElementById(pos + "-all");
                // 清空子节点
                while (posNode.hasChildNodes()) {
                    posNode.removeChild(posNode.firstChild);
                }
                // 展示结果
                for (i = 0; i < len; i++) {
                    var otherPlace = document.createElement("div");
                    otherPlace.className = "other-place";
                    var para = document.createElement("p");
                    para.innerHTML = places[i];
                    otherPlace.appendChild(para);
                    posNode.appendChild(otherPlace);
                }
                if (pos == "start_more") {
                    start_times += 1000;
                } else {
                    end_times += 1000;
                }
            }
        }
        request.setRequestHeader("Content-Type",
                     "application/x-www-form-urlencoded");
        request.send();
    }
}


nearStart.onclick = function () {
    var currentUrl = "SearchNearStartAdress?" + url + "&&scope=" + start_times + "&&date=" + date;
    getNewContent(currentUrl, "start_more");

}

nearEnd.onclick = function () {
    var currentUrl = "SearchNearEndAdress?" + url + "&&scope=" + end_times + "&&date=" + date;
    getNewContent(currentUrl, "end_more");
}