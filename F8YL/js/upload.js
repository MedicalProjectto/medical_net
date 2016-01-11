var BASE_URL = "http://localhost:50403/";
var sum = 0;
var maxSum = 1;
var maxSize = 3;
// 初始化Web Uploader
var uploader = WebUploader.create({
    // 选完文件后，是否自动上传。
    auto: true,
    // swf文件路径
    swf: BASE_URL + 'js/Uploader.swf',
    // 文件接收服务端。
    server: BASE_URL + 'Handler.ashx',
    // 选择文件的按钮。可选。
    // 内部根据当前运行是创建，可能是input元素，也可能是flash.
    pick: {
        id: '#filePicker',
        multiple: true
    },
    method: 'post',
    // 验证文件总数量, 超出则不允许加入队列
    fileNumLimit: maxSum,
    // 验证单个文件大小是否超出限制, 超出则不允许加入队列。
    fileSingleSizeLimit: maxSize * 1024 * 1024,
    // 只允许选择图片文件。
    accept: {
        title: 'Images',
        extensions: 'gif,jpg,jpeg,bmp,png',
        mimeTypes: 'image/*'
    }
});
// 当有文件添加进来的时候
uploader.on('fileQueued', function (file) {
    uploader.makeThumb(file, function (error, src) {
        //上传好的图片
        alert(src);
    });
});

//文件上传限制
uploader.on('error', function (handler) {
    //alert(handler)
    if (handler == "F_EXCEED_SIZE")
        alert("文件大小超过限制，最大可上传3M的图片");
    if (handler == "F_DUPLICATE")
        alert("相同的图片不允许重复上传");
    if (handler == "Q_EXCEED_NUM_LIMIT")
        alert("最多只可以上传3张图片");
    if (handler == "Q_TYPE_DENIED")
        alert("请选择图片格式的文件，支持{gif,jpg,jpeg,bmp,png}");
});