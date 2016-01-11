/***********Create By Landry 20150930*************/
jQuery.extend({
    showUploadDialog: function (options, api) {
        var json = {};
        if (options.params) {
            json = options.params;
        }
      
        $("<form action='' method='post' id='fileUploadForm'  enctype='multipart/form-data' ><div id='fileUpload'></div></form>").attr("title", '上传').append("<p><span><input type='hidden' name='MAX_FILE_SIZE' value='1000'/><input type='file' id='inputFileUpload' max='1000'  name='file'/></span></p>").appendTo("body").dialog({
            bgiframe: true,
            resizable: false,
            modal: true,
            width: 450,
            overlay: {
                backgroundColor: '#000',
                opacity: 0
            },
            zIndex: 1050,
            buttons: {
                '上 传': function () {
                    $(this).dialog('destroy');
                    $("#fileUpload").remove();
                    
                    //alert(WII.APIs.domain + '/' + WII.APIs.PatientOpt + "/" + WII.APIs.PatientOpt.PostFileUpload);
                    var option = {
                        type: 'post',
                        url: WII.APIs.domain + '/' + 'PatientOpt/PostFileUpload/?json='+JSON.stringify(json),
                        dataType: "json",
                        //data:{ 'json':JSON.stringify(json)},
                        beforeSubmit: function () {
                           
                        },
                        success: function (result) {
                            $("form").remove();
                            var RetCode = result.hasOwnProperty('RetCode') ? result.RetCode : undefined ,
                                RetMsg = result.hasOwnProperty('RetMsg') ? result.RetMsg : '返回消息缺失' ,
                                RetObj = result.hasOwnProperty('RetObj') ? result.RetObj : undefined ;
                            if (RetCode == 1) {
                                if (typeof options.success == 'function') {
                                    options.success(RetObj);
                                }
                            }else if(RetCode == 200 || RetCode == 300 ){
                                console.error(" Error Message : [ code : " + msg.RetCode + " ] " + RetMsg);
                            }else if(RetCode == 20 || RetCode == 100){
                                if (RetMsg != null && RetMsg.length > 0){
                                    alert(RetMsg);
                                }
                            }else{
                                console.error(" Error Message : [ code : " + RetCode + " ] " + RetMsg +' 返回信息没有RetCode ');
                            }
                        },
                        error: function (result) {
                            $("form").remove();
                            if (typeof options.error == 'function') {
                                options.error(result);
                            }
                        }
                    };
                    $('#fileUploadForm').ajaxSubmit(option);
                },
                '关闭': function () {
                    $(this).dialog('destroy');
                    $("#fileUpload").remove();
                    $("#inputFileUpload").remove();
                    $("form").remove();
                }
            },
            close: function (event, ui) {
                $(this).dialog('destroy');
                $("#fileUpload").remove();
                $("#inputFileUpload").remove();
                $("form").remove();
            },
            open: function (event, ui) {
                $("#fileUpload").appendTo("form");
            }
        });
    }
});