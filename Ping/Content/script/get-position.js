var suggestId1 = document.getElementById("suggestId1");
var suggestId2 = document.getElementById("suggestId2");

suggestId1.onmouseover() = function(){
     var posName = suggestId1.value;
     var myGeo = new BMap.Geocoder();
	// 将地址解析结果显示在地图上,并调整地图视野
        myGeo.getPoint(posName, function(point){
            if (point) {
               
            }
        }, "北京市");
     consloe.log();
}