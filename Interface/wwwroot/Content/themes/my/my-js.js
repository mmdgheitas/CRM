function FixJqueryStyle(Name) {
    $("#jqGrid" + Name).jqGrid('inlineNav', "#jqGridPager" + Name);

    $(".ui-jqgrid").removeClass("ui-widget ui-widget-content");

    jQuery(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");

    jQuery(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");

    //jQuery(".ui-jqgrid-pager").removeClass("ui-state-default");
    //jQuery(".ui-jqgrid").removeClass("ui-widget-content");

    jQuery(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
    $(".ui-jqgrid-htable").find(".ui-jqgrid-sortable").css("text-align", "right").first().css("text-align", "center");

    $(".ui-icon.glyphicon.glyphicon-refresh").addClass("btn btn-sm btn-primary");
    $(".ui-icon.glyphicon.glyphicon-edit").addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-edit-text").parent().addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-plus").addClass("btn btn-sm btn-success");
    $(".ui-icon.glyphicon.glyphicon-plus-text-primary").parent().addClass("btn btn-sm btn-primary");
    $(".ui-icon.glyphicon.glyphicon-plus-text-success").parent().addClass("btn btn-sm btn-success");
    $(".ui-icon.glyphicon.glyphicon-plus-text-info").parent().addClass("btn btn-sm btn-info");
    $(".ui-icon.glyphicon.glyphicon-plus-text-danger").parent().addClass("btn btn-sm btn-danger");
    $(".ui-icon.glyphicon.glyphicon-plus-text-warning").parent().addClass("btn btn-sm btn-warning");
    $(".ui-icon.ui-icon-search").removeClass().addClass("fa fa-search").addClass("btn btn-sm btn-info");
    $(".ui-icon.ui-icon-search").removeClass().addClass("fa fa-search").addClass("btn btn-sm btn-info");
    $(".ui-icon.glyphicon.glyphicon-trash").removeClass().addClass("fa fa-trash-o").addClass("btn btn-sm btn-danger");
    $(".ui-icon.ui-icon-seek-prev").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-prev").removeClass().addClass("fa fa-backward");

    $(".ui-icon.ui-icon-seek-first").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-first").removeClass().addClass("fa fa-fast-backward");

    $(".ui-icon.ui-icon-seek-next").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-next").removeClass().addClass("fa fa-forward");

    $(".ui-icon.ui-icon-seek-end").wrap("<div class='btn btn-sm btn-default'></div>");
    $(".ui-icon.ui-icon-seek-end").removeClass().addClass("fa fa-fast-forward");


    //For checkbx
    $("#cb_jqGrid").parent().parent().css("padding-bottom", "15px");

    //----- MoveableModal
    $('.modal-dialog').draggable({
        handle: ".modal-header"
    });
    $('#myModal').on('shown.bs.modal', function () {
        $(".modal-header").css("cursor", "move");
    })
};

function printAllData(action) {





    var selRowId = $("#jqGrid").getGridParam("selrow");

    if (selRowId == null) {
        showMessage("لطفا یک رکورد راانتخاب کنید!", "error");
        return;
    }

    // return;
    $.ajax({
        url: "/Report/" + action + "",
        type: 'POST',
        data: { id: selRowId },
        dataType: 'json',
        success: function (msg) {

            if (msg != null && msg.success) {
                showMessage(msg.responseText, "success");
                window.location.href = "/Report/PrintData";
            }
            else if (msg != null && !msg.success) {
                showMessage(msg.responseText, "error");
            }
        },
        error: function (msg) {
            showMessage("خطا در ارسال اطلاعات،لطفا بعدا تلاش کنید", "error");
        }
    });
};


function status(cellvalue) {
    if (cellvalue == true)
        return "فعال";
    else
        return "غیرفعال";
};
function statusDefault(cellvalue) {
    if (cellvalue == true)
        return "پیش فرض";
    else
        return "عادی";
};
function Direction(cellvalue) {
    if (cellvalue == true)
        return "راست چین";
    else
        return "چپ چین";
};


function showMessage(msg, status) {
    toastr.options = { "closeButton": true, "progressBar": true, "positionClass": "toast-top-full-width" };

    if (status == "success") {
        if (typeof toastr != 'undefined')
            toastr.success(msg);
        else alert(msg);
    }
    else if (status == "error") {
        if (typeof toastr != 'undefined') {
            toastr.error(msg);
        }
        else alert(msg);
    }
    else if (status == "info") {
        if (typeof toastr != 'undefined')
            toastr.info(msg);
        else alert(msg);
    }
    else if (status == "warning") {
        if (typeof toastr != 'undefined')
            toastr.warning(msg);
        else alert(msg);
    }

};

function reloadGrid() {
    $("#jqGrid").setGridParam({ datatype: 'json' });
    $('#jqGrid').trigger('reloadGrid');
};

function showAddDialog(controller, action) {
    myLoading('start');
    $.ajax({
        url: "/" + controller + "/" + action + "",
        type: "get",
        success: function (result) {
            $("#modalBody").html(result);
            myLoading('stop');
            $("#myModal").modal("show");
        }
    })
};

function showEditDialog(controller, action) {
    var selRowId = $("#jqGrid").getGridParam("selrow");

    if (selRowId == null) {
        showMessage("لطفا یک رکورد راانتخاب کنید!", "error");
        return;
    }
    else {
        myLoading('start');
        $.ajax({
            url: "/" + controller + "/" + action + "?mode=edit",
            type: "get",
            data: { id: selRowId },
            success: function (result) {
                $("#modalBody").html(result);
                myLoading('stop');
                $("#myModal").modal("show");
            }
        })
    }
};

function showDeleteRow(controller, action) {
    var selRowId = $("#jqGrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("لطفا یک رکورد راانتخاب کنید!", "error");
        return;
    }
    if (confirm('میخواهید رکورد را حذف کنید؟')) {
        $.ajax({
            url: "/" + controller + "/" + action + "",
            type: "get",
            data: { id: selRowId },
            success: function (msg) {
                if (msg != null && msg.success) {
                    showMessage(msg.responseText, "success");
                    reloadGrid();
                }
                else if (msg != null && !msg.success) {
                    showMessage(msg.responseText, "error");
                }
            },
            error: function (msg) {

                alert("خطا..! لطفا بعدا تلاش کنید");
            }
        })
    }


};

function showDeleteUser(controller, action) {
    var selRowId = $("#jqGrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("لطفا یک رکورد راانتخاب کنید!", "error");
        return;
    }
    if (confirm('میخواهید رکورد را حذف کنید؟') == false) {
        return false;
    }
    if (confirm('با حذف کاربر تمام اطلاعات مربوط به کاربر در سیستم پاک خواهد شد، آیا ادامه میدهید؟') == false) {
        return false;
    }
    $.ajax({
        url: "/" + controller + "/" + action + "",
        type: "get",
        data: { id: selRowId },
        success: function (msg) {
            if (msg != null && msg.success) {
                showMessage(msg.responseText, "success");
                reloadGrid();
            }
            else if (msg != null && !msg.success) {
                showMessage(msg.responseText, "error");
            }
        },
        error: function (msg) {
            alert("خطا..! لطفا بعدا تلاش کنید");
        }
    })



};


function myLoading(action) {
    if (action == 'start') {
        $('body').loading({
            theme: 'dark',
            message: 'در حال بارگذاری....'
        });
    }
    else if (action == 'stop') {
        $('body').loading('stop');
    }
};


/////////////////////////////////////////////
function ChoosePicture()
{ }
function ShowPicture(elem) {
    var WebuiPopovers = $('button[rel=popover]').webuiPopover({
        title: 'تصویر انتخاب شده',
        direction: 'rtl',
        trigger: 'hover',
        animation: 'pop',
        placement: 'bottom-left',
        type: 'html',
        cache: false,

        content: function () { return '<img src="' + elem.val() + '" style="width:200px;height:200px;" />'; },

    });

};
function BrowseServer() {
    // You can use the "CKFinder" class to render CKFinder in a page:
    var finder = new CKFinder();
    finder.basePath = '../';	// The path for the installation of CKFinder (default = "/ckfinder/").
    finder.selectActionFunction = SetFileField;
    finder.popup();
}

function EnableHelp(elem) {
    var WebuiPopovers = $('#help').webuiPopover({
        title: $("#HelpTitle").val(),
        direction: 'rtl',
        trigger: 'click',
        animation: 'fade',
        placement: 'bottom-right',
        type: 'html',
        style: 'default',
        cache: true,
        arrow: true,
        width: '500',
        content: function () { return $("#HelpContent").val(); },
        onShow: function () {
            $('.webui-popover').draggable({
                handle: ".webui-popover-title"
            });
            $(".webui-popover-title").css("cursor", "move");
        }
    });


};



////////////////////////////////////
function AddEditUploadFile(form, controller, action, mode) {

    modalBody = $("#modalBody").html();
    $("form#" + form + "").submit(function (e) {
        e.preventDefault();
        if ($("form#" + form + "").valid()) {
            var btn = $("#saveBtn");
            btn.button('loading');
            var data = $("form#" + form + "").serialize();

            $.ajax(
                {
                    url: "/" + controller + "/" + action + "?mode=" + mode,
                    type: "post",
                    data: data,
                    success: function (msg) {
                        btn.button('reset');
                        if (msg != null && msg.success) {


                            //Upload File....
                            $.ajaxFileUpload({
                                url: "/" + "Account" + "/" + "UploadFile", // مسيري كه بايد فايل به آن ارسال شود
                                secureuri: false,
                                fileElementId: 'UploadImage', // آي دي المان ورودي فايل
                                dataType: 'json',
                                data: { id: msg.UserID, }, // اطلاعات اضافي در صورت نياز
                                success: function (data) {

                                    if (data != null && data.success) {

                                    }
                                    else if (data != null && !data.success) {
                                        showMessage(data.responseText, "error");
                                    }
                                },
                                error: function (data, status, e) {

                                    alert('متاسفانه عکس آپلود نشد،دوباره تلاش کنید');
                                },
                                complete: function (data) {
                                    btn.button('reset');
                                    showMessage(msg.responseText, "success");

                                    reloadGrid();
                                    if ($("#closeModal").is(':checked')) $("#myModal").modal("hide");
                                    else if (mode == "add") { $("#modalBody").html(modalBody); $('#closeModal').attr('checked', false); }
                                }
                            });

                            //-------------







                        }
                        else if (msg != null && !msg.success) {
                            btn.button('reset');
                            showMessage(msg.responseText, "error");
                        }
                    },
                    error: function (msg) {
                        btn.button('reset');
                        alert("خطا..! لطفا بعدا تلاش کنید");
                    }
                });
        }
    });
}



function AddEditUploadPDF(form, controller, action, mode) {

    modalBody = $("#modalBody").html();
    $("form#" + form + "").submit(function (e) {
        if ($("#isConfirmed").val() == "1") {
            showMessage('چون اثر شما توسط اپراتور تایید شده است،دیگر نمیتوانید آن را ویرایش کنید', "error");
            return false;
        }
        if ($("#UploadPDF").val() == "" & mode == "add") {
            showMessage('لطفا فایل  اثر را آپلود کنید', "error");
            return false;
        }

        if ($("#UploadPDF").val() == "" && mode == "edit" && $("#isFileUpload").val() == "False") {
            showMessage('لطفا فایل  اثر را آپلود کنید', "error");
            return false;
        }


        e.preventDefault();
        if ($("form#" + form + "").valid()) {

            var btn = $("#saveBtn");
            btn.button('loading');
            var data = $("form#" + form + "").serialize();
            $.ajax(
                {
                    url: "/" + controller + "/" + action + "?mode=" + mode,
                    type: "post",
                    data: data,
                    success: function (msg) {

                        if (msg != null && msg.success) {


                            $("#ID").val(msg.ID);

                            //Upload File....
                            $.ajaxFileUpload({
                                url: "/" + "Account" + "/" + "UploadPDF", // مسيري كه بايد فايل به آن ارسال شود
                                secureuri: false,
                                fileElementId: 'UploadPDF', // آي دي المان ورودي فايل
                                dataType: 'json',
                                data: { id: msg.ID, }, // اطلاعات اضافي در صورت نياز
                                success: function (data) {

                                    if (data != null && data.success) {
                                        showMessage(msg.responseText, "success");
                                        btn.button('reset');
                                        reloadGrid();
                                        if ($("#closeModal").is(':checked')) $("#myModal").modal("hide");
                                        else if (mode == "add") { $("#modalBody").html(modalBody); $('#closeModal').attr('checked', false); }
                                    }
                                    else if (data != null && !data.success) {
                                        showMessage(data.responseText, "error");
                                        btn.button('reset');

                                    }


                                },
                                error: function (data, status, e) {

                                    alert('متاسفانه عکس آپلود نشد،دوباره تلاش کنید');
                                },
                                complete: function (data) {

                                }
                            });

                            //-------------







                        }
                        else if (msg != null && !msg.success) {
                            btn.button('reset');
                            showMessage(msg.responseText, "error");
                        }
                    },
                    error: function (msg) {
                        btn.button('reset');
                        alert("خطا..! لطفا بعدا تلاش کنید");
                    }
                });
        }
    });
}

function AddEditUploadFile2(form, controller, action, mode) {

    modalBody = $("#modalBody").html();
    $("form#" + form + "").submit(function (e) {
        if ($("#isConfirmed").val() == "1") {
            showMessage('چون اثر شما توسط اپراتور تایید شده است،دیگر نمیتوانید آن را ویرایش کنید', "error");
            return false;
        }
        if ($("#UploadPDF").val() == "" & mode == "add") {
            showMessage('لطفا فایل  اثر را آپلود کنید', "error");
            return false;
        }

        if ($("#UploadPDF").val() == "" && mode == "edit" && $("#isFileUpload").val() == "False") {
            showMessage('لطفا فایل  اثر را آپلود کنید', "error");
            return false;
        }


        e.preventDefault();
        if ($("form#" + form + "").valid()) {

            var btn = $("#saveBtn");
            btn.button('loading');
            var data = $("form#" + form + "").serialize();
            $.ajax(
                {
                    url: "/" + controller + "/" + action + "?mode=" + mode,
                    type: "post",
                    data: data,
                    success: function (msg) {

                        if (msg != null && msg.success) {


                            $("#ID").val(msg.ID);

                            //Upload File....
                            $.ajaxFileUpload({
                                url: "/" + "Account" + "/" + "UploadFile2", // مسيري كه بايد فايل به آن ارسال شود
                                secureuri: false,
                                fileElementId: 'UploadFile', // آي دي المان ورودي فايل
                                dataType: 'json',
                                data: { id: msg.ID, }, // اطلاعات اضافي در صورت نياز
                                success: function (data) {

                                    if (data != null && data.success) {
                                        showMessage(msg.responseText, "success");
                                        btn.button('reset');
                                        reloadGrid();
                                        if ($("#closeModal").is(':checked')) $("#myModal").modal("hide");
                                        else if (mode == "add") { $("#modalBody").html(modalBody); $('#closeModal').attr('checked', false); }
                                    }
                                    else if (data != null && !data.success) {
                                        showMessage(data.responseText, "error");
                                        btn.button('reset');

                                    }


                                },
                                error: function (data, status, e) {

                                    alert('متاسفانه عکس آپلود نشد،دوباره تلاش کنید');
                                },
                                complete: function (data) {
                                    btn.button('reset');
                                }
                            });

                            //-------------







                        }
                        else if (msg != null && !msg.success) {
                            btn.button('reset');
                            showMessage(msg.responseText, "error");
                        }
                    },
                    error: function (msg) {
                        btn.button('reset');
                        alert("خطا..! لطفا بعدا تلاش کنید");
                    }
                });
        }
    });
}

function deleteImageProfile(elem) {
    var UserID = $(elem).attr("data-UserID");

    $.ajax(
        {
            url: "/" + "Account" + "/" + "DeleteImageProfile",
            type: "post",
            data: { id: UserID },
            success: function (msg) {

                if (msg != null && msg.success) {
                    $("#displayImage").attr("src", "/Content/Files/ProfileImages/default-image.jpg");
                    $("#UploadImage").val(null);
                }
                else if (msg != null && !msg.success) {

                    showMessage(msg.responseText, "error");
                }
            },
            error: function (msg) {
                showMessage('خطا در حذف عکس، لطفا بعدا تلاش کنید', "error");
            }
        });
}

function AddEditForm(form, controller, action, mode) {
    alert('2');
    modalBody = $("#modalBody").html();
    $("form#" + form + "").submit(function (e) {

        e.preventDefault();
        if ($("form#" + form + "").valid()) {
            var btn = $("#saveBtn");
            btn.button('loading');
            var data = $("form#" + form + "").serialize();
            $.ajax(
                {
                    url: "/" + controller + "/" + action + "?mode=" + mode,
                    type: "post",
                    data: data,
                    success: function (msg) {
                        btn.button('reset');
                        if (msg != null && msg.success) {
                            showMessage(msg.responseText, "success");

                            reloadGrid();
                            if ($("#closeModal").is(':checked')) $("#myModal").modal("hide");
                            else if (mode == "add") { $("#modalBody").html(modalBody); $('#closeModal').attr('checked', false); }

                        }
                        else if (msg != null && !msg.success) {
                            btn.button('reset');
                            showMessage(msg.responseText, "error");
                        }
                    },

                    error: function (msg) {
                        btn.button('reset');
                        alert("خطا..! لطفا بعدا تلاش کنید");
                    }
                });
        }
    });
}



function getLocationDes(ip) {
    if (ip == null) {
        showMessage("خطا در گرفتن اطلاعات مکان کاربر!", "error");
        return;
    }
    else {
        myLoading('start');
        $.ajax({
            url: "/Visitor/_LocationDescription",
            type: "post",
            data: { ip: ip },
            success: function (result) {
                $("#modalBody").html(result);
                myLoading('stop');
                $("#myModal").modal("show");
            },
            error: function (result) {
                myLoading('stop');
                alert('خطا! لطفا بعدا تلاش کنید');
            }
        })
    }
}


function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#displayImage').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
};


function ShowAlert(Message,Type)
{
    var retuenPM = "<div class=\"alert alert-" + Type + " margin-bottom-30\" style=\"text-align:right; display:normal;\">";
    retuenPM += "<button type =\"button\" class=\"close\" data-dismiss=\"alert\"><span aria-hidden=\"true\">×</span><span class=\"sr-only\">Close</span></button>";
    retuenPM += Message;
    retuenPM += "</div>";
    return retuenPM;
}
function ChangePasswordChange() {
    $("#ChangePassword").change(function () {
        if (this.checked) {
            $("#Password").removeAttr("disabled");

        }
        else {
            $("#Password").attr("disabled", "disabled");
        }
    });
}

function UploadImageChange() {
    $("#UploadImage").change(function () {
        readURL(this);
    });
}

function CollegeChanged() {
    $("#CollegeID").change(function () {
        $.ajax(
                  {
                      url: "/Account/_FieldList",
                      data: { id: $("#CollegeID").val() },
                      type: "Post",
                      cache: false,
                      success: function (result) {
                          $("#ListField").html(result.Html);
                      }
                  });
    });
}

$(document).ready(function () {




});

//-------------------------------------------------jqGrid Function
function fullNameFormatter(cellvalue, options, rowObject) {
    cellvalue = cellvalue == null ? '' : cellvalue;
    rowObject.LastName = rowObject.LastName == null ? '' : rowObject.LastName;
    return cellvalue + ' ' + rowObject.LastName;
};
function DisplayImageInJqGrid(cellvalue, options, rowObject) {
    var image = rowObject["Image"];
    return "<img alt=\"تصویر کاربر\" src=\"/Content/Files/ProfileImages/" + (image != null ? image : "default-image.jpg") + "\" class=\"\"  width=\"25\" height=\"25\">";
};


