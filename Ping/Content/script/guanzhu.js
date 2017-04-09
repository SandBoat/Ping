var guanzhu = document.getElementById("guanzhu");
var listId = guanzhu.getAttribute("data-listId");
var xmlHttp;

guanzhu.onclick = function () {
    if (guanzhu.className == "") {
        follow(listId);
    }
    else {
        unFollow(listId);
    }
}

function changeBtn() {
    var p = guanzhu.childNodes[0];
    if (guanzhu.className == "") {
        guanzhu.className = "button-click";
        p.nodeValue = "已关注";
    }
    else {
        guanzhu.className = "";
        p.nodeValue = "关注";
    }
}

function follow(listId) {
    //  异步请求Url
    var url = "../Follow?listId=" + listId;
    sendXMLHttpRequest(url);
}

function unFollow(listId) {
    //  异步请求Url
    var url = "../UnFollow?listId=" + listId;
    sendXMLHttpRequest(url);
}

function sendXMLHttpRequest(url) {
    createXMLHttpRequest();
    xmlHttp.onreadystatechange = handleStateChange;
    xmlHttp.open("POST", url);
    xmlHttp.setRequestHeader("Content-Type",
                     "application/x-www-form-urlencoded");
    xmlHttp.send();
}

function createXMLHttpRequest() {
    if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
}
function handleStateChange() {
    if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
        if (xmlHttp.responseText === "ok") {
            changeBtn();
        } else if (xmlHttp.responseText === "login") {
            window.location.href = "http://ghy.swufe.edu.cn/hq/Ping/User/Login";
        }
    }
}