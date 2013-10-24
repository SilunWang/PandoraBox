var flag = false;
function DrawImage(ImgD, iwidth, iheight) {
    //参数(图片,允许的宽度,允许的高度)
    var image = new Image();
    image.src = ImgD.src;
    if (image.width > 0 && image.height > 0) {
        flag = true;
        if (image.width / image.height >= iwidth / iheight) {
            if (image.width > iwidth) {
                ImgD.width = iwidth;
                ImgD.height = (image.height * iwidth) / image.width;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
        }
        else {
            if (image.height > iheight) {
                ImgD.height = iheight;
                ImgD.width = (image.width * iheight) / image.height;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
        }
    }
}
//遍历窗口中每一个img
function Init() {
    var obj = document.getElementsByClassName("MidImg");
    for (var j = 0; j < obj.length; j++) {
        DrawImage(obj[j], 75, 75);
    }
    var obj = document.getElementsByClassName("tinyImg");
    for (var j = 0; j < obj.length; j++) {
        DrawImage(obj[j], 50, 50);
    }
}
