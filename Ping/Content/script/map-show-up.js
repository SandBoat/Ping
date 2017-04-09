var suggest1 = document.getElementById("suggestId1");
var suggest2 = document.getElementById("suggestId2");
map = document.getElementById("l-map");

function showmap(){
    document.getElementById("l-map").style.visibility = "visible";
}

suggest1.onclick = function(){
    showmap();
}

suggest2.onclick = function(){
    showmap();
}
