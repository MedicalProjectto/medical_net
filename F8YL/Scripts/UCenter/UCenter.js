$(function () {
    $('input, textarea').placeholder();
    var regMobile = /^(13[0123456789][0-9]{8}|15[012356789][0-9]{8}|18[02356789][0-9]{8}|147[0-9]{8}|1349[0-9]{7})$/;
    var regIdCard = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
    var regPhone = /^0?1[3|4|5|8][0-9]\d{8}$/;
    var regEmail = /^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/;
    //保存用户信息
    $(".btn_pd_save").click(function () {
        var name = $("#username").val();
        var truename = name;
        if (name == "") {
            alert("请填写姓名！");
            return;
        }
        var dept = $("#dept").val();
        //if (dept == "") {
        //    alert("请填写科室！");
        //    return;
        //}
        //var ava = $("#header-pic").attr("src");
        //alert(ava);
        var avatar = encodeURIComponent($("#header-pic").attr("src").replace(/http\:\/\/.+?\//, '/'));
        //alert(avatar);
        //if(avatar == ""){
        //    alert("请上传头像！");
        //    return;
        //}
        var jobtitle = $("#jobtitle").val();
        var telphone = $("#telphone").val();

        var jobtitle = $("#jobtitle").val();
        //if(telphone!="" && !regPhone.test(telphone)){
        //    alert("电话格式不正确！");
        //    return;
        //}
        var idcard = $("#idcard").val();
        if (idcard == "") {
            alert("请填写身份证！");
            return;
        }
        if (!regIdCard.test(idcard)) {
            alert("身份证格式不正确！");
            return;
        }
        var email = $("#email").val();
        if (email != "" && !regEmail.test(email)) {
            alert("邮箱格式不正确！");
            return;
        }
        //var hospitalname = $("#hospitalname").val();
        //根据身份证计算年龄
        var date = new Date();
        var year = date.getFullYear();
        var birthday_year = parseInt(idcard.substr(6, 4));
        var userage = year - birthday_year;
        //if (email) {//邮箱不必填
        //    if (!regEmail.test(email)) {
        //        alert('请输入正确的邮箱格式！');
        //        return;
        //    }
        //}
        //if (!username || !idcard || !mobile) {
        //    alert('请填写完成资料！');
        //}
        //else if (!regPhone.test(mobile)) {
        //    alert('请输入正确的手机号码！');
        //}
        //else if (!regIdCard.test(idcard)) {
        //    alert('请输入正确的身份证号码！');
        //}
        //var userid = $("#hidden-userid").val();
        var userid = "";
        var datajson = {
            "username": name,
            "truename": truename,
            "deptid": dept,
            "avatar": avatar,
            "age": userage,
            "duty": jobtitle,
            "tel": telphone,
            "email": email,
            "userid": userid
        };

        $.ajax({
            url: "/F8YLUCenter/SaveUser",
            contentType: "application/json; charset=utf-8",
            type: "POST",
            data: JSON.stringify(datajson),
            dataType: "json",
            success: function (retData) {

                if (retData.code == 0) {
                    alert("保存成功");

                    $(".btn_cancel").click();
                    //$("#useravatar").attr("src", retData.data.avatar);
                    if (typeof (userid) != "undefined") {
                        if (userid == "") {
                            $("#show_username").text(retData.data.username);
                        }
                        else {
                            //$("#show_username").text(retData.data.username);
                            $(".hospital_members #" + userid + " .margin-w10").text(retData.data.username)
                        }
                    }
                    


                    $("#personal_data").css("display", "none");
                } else
                    alert(retData.message);

                //$("#hidden-userid").val("");
            },
            error: function (e) {
                alert(e);
            }

        })
    })

    //修改用户密码
    $(".btn_cp_save").click(function () {
        var pass_old = $.trim($('#passold').val());
        if (pass_old == "") {
            alert("请输入当前密码！");
            return;
        }

        var pass_new1 = $.trim($("#passnew1").val());
        if (pass_new1 == "") {
            alert("请输入新密码！");
            return;
        }
        var pass_new2 = $.trim($("#passnew2").val());
        if (pass_new2 == "") {
            alert("请输入再次输入新密码！");
            return;
        }
        if (pass_new1 != pass_new2) {
            alert("新密码输入不一致！");
            return;
        }

        var datajson = {
            "pass_old": pass_old,
            "pass_new1": pass_new1,
            "pass_new2": pass_new2
        };

        $.ajax({
            url: "/F8YLUCenter/ModifyUserPassword",
            contentType: "application/json; charset=utf-8",
            type: "POST",
            data: JSON.stringify(datajson),
            dataType: "json",
            success: function (retData) {

                if (retData.code == 0) {
                    if (confirm("修改密码成功,您确定要重新登录吗?")) {
                        window.location.href = "/F8YLHome/Index";
                    } else {
                        $("#passold").val("");
                        $("#passnew1").val("");
                        $("#passnew2").val("");
                    }
                }
                else
                    alert(retData.message);

            },
            error: function (e) {
                alert(e);
            }

        })
    })

    //这种方式不能跳转??原因没搞清楚
    $(".btn_exit").click(function () {
        //$.get("");
        window.location.href = "/F8YLUCenter/Logout";
    })
    //$(".btn_exit").attr("href", "/F8YLUCenter/Logout");
    //点击其他位置关闭弹出
    $(document).mouseup(function (e) {
        var _con = $('#user_settings,#btn_user,.tab_Doctor,.tab_Patient');   // 设置目标区域
        if (!_con.is(e.target) && _con.has(e.target).length === 0) { // Mark 1
            $('#user_settings').hide();//个人设置
            $('.tab_Doctor,.tab_Patient').hide();//医生病人信息框
        }
    });
})