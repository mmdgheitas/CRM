

function styleJqGrid(Name) {


    $("#jqgrid" + Name).jqGrid('inlineNav', "#jqGridPager" + Name);

    $(".ui-jqgrid").removeClass("ui-widget ui-widget-content");

    jQuery(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");

    //  jQuery(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");

    //  //jQuery(".ui-jqgrid-pager").removeClass("ui-state-default");
    //  //jQuery(".ui-jqgrid").removeClass("ui-widget-content");

    jQuery(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
    $(".ui-jqgrid-htable").find(".ui-jqgrid-sortable").css("text-align", "right").first().css("text-align", "center");

    $(".ui-icon.glyphicon.glyphicon-refresh").addClass("btn btn-sm btn-primary");
    $(".ui-icon.glyphicon.glyphicon-print").addClass("btn btn-sm btn-blue");
    $(".ui-icon.glyphicon.glyphicon-edit").addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-info-text").addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-plus-text-info").parent().addClass("btn btn-sm btn-info");
    $(".ui-icon.glyphicon.glyphicon-edit-text").parent().addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-plus").addClass("btn btn-sm btn-success");
    $(".ui-icon.glyphicon.glyphicon-plus-text-success").parent().addClass("btn btn-sm btn-success");
    $(".ui-icon.glyphicon.glyphicon-plus-text-danger").parent().addClass("btn btn-sm btn-danger");
    $(".ui-icon.glyphicon.glyphicon-plus-text-warning").parent().addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-plus-text-default").parent().addClass("btn btn-sm btn-default");
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


    //    $("#jqgrid").closest("div.ui-jqgrid-view")
    //.children("div.ui-jqgrid-titlebar")
    //.css("text-align", "center")
    //.children("span.ui-jqgrid-title")
    //.css("float", "none");



    //For checkbx
    //$("#cb_jqGrid").parent().parent().css("padding-bottom", "15px");

    //$("#jqGridPager_left").insertBefore("#jqGridPager_right");
    // $("#jqGridPager_right").insertBefore("#jqGridPager_center");
    $("#jqGridPager_center").insertBefore("#jqGridPager_left");
    ////$("#jqGridPager_left").css("width", "200px");
    //// $("#jqGridPager_center").css("padding-right", "240px");
    //$("#jqGridPager_center").css("padding-right", "300px");


    //----- MoveableModal
    MoveableModal();


};

function styleJqTree(Name) {
    $("#tree" + Name).jqGrid('inlineNav', "#jqGridPager" + Name);
    $(".ui-jqgrid").removeClass("ui-widget ui-widget-content");

    jQuery(".ui-jqgrid-view").children().removeClass("ui-widget-header ui-state-default");

    //  jQuery(".ui-jqgrid-labels, .ui-search-toolbar").children().removeClass("ui-state-default ui-th-column ui-th-ltr");

    //  //jQuery(".ui-jqgrid-pager").removeClass("ui-state-default");
    //  //jQuery(".ui-jqgrid").removeClass("ui-widget-content");

    jQuery(".ui-jqgrid-htable").addClass("table table-bordered table-hover");
    $(".ui-jqgrid-htable").find(".ui-jqgrid-sortable").css("text-align", "right").first().css("text-align", "center");

    $(".ui-icon.glyphicon.glyphicon-refresh").addClass("btn btn-sm btn-primary");
    $(".ui-icon.glyphicon.glyphicon-print").addClass("btn btn-sm btn-blue");
    $(".ui-icon.glyphicon.glyphicon-edit").addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-info-text").addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-plus-text-info").parent().addClass("btn btn-sm btn-info");
    $(".ui-icon.glyphicon.glyphicon-edit-text").parent().addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-plus").addClass("btn btn-sm btn-success");
    $(".ui-icon.glyphicon.glyphicon-plus-text-success").parent().addClass("btn btn-sm btn-success");
    $(".ui-icon.glyphicon.glyphicon-plus-text-danger").parent().addClass("btn btn-sm btn-danger");
    $(".ui-icon.glyphicon.glyphicon-plus-text-warning").parent().addClass("btn btn-sm btn-warning");
    $(".ui-icon.glyphicon.glyphicon-plus-text-default").parent().addClass("btn btn-sm btn-default");
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


    $("#jqGridPager_left").insertBefore("#jqGridPager_right");
    $("#jqGridPager_right").insertBefore("#jqGridPager_center");

    $("#jqGridPager_left").css("width", "300px");
    // $("#jqGridPager_center").css("padding-right", "240px");
    $("#jqGridPager_center").css("padding-right", "400px");

    //----- MoveableModal
    MoveableModal();


};
function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};
function jqGridLastWidth(jqgWidth) {


    var length = $('#content').width() - jqgWidth - 65;

    if (length - 50 < 0)
        return 120;
    else
        return length;


}

function InitilizeLobibox() {
    Lobibox.base.OPTIONS = $.extend({}, Lobibox.base.OPTIONS, {
        modalClasses: {
            'confirm': 'lobibox-info',
            'error': 'lobibox-error',
            'success': 'lobibox-success',
            'info': 'lobibox-info',
            'warning': 'lobibox-warning',
            'progress': 'lobibox-progress',
            'prompt': 'lobibox-info ',
            'default': 'lobibox-default',
            'window': 'lobibox-window'
        },
        buttons: {
            ok: {
                'class': 'lobibox-btn lobibox-btn-default',
                text: 'OK',
                closeOnClick: true
            },
            cancel: {
                'class': 'lobibox-btn lobibox-btn-cancel',
                text: 'Cancel',
                closeOnClick: true
            },
            yes: {
                'class': 'lobibox-btn lobibox-btn-yes',
                text: 'Yes',
                closeOnClick: true
            },
            no: {
                'class': 'lobibox-btn lobibox-btn-cancel',
                text: 'No',
                closeOnClick: true
            }
        }
    });
}
function scrollToElement(elementId) {
    var element = document.getElementById(elementId);
    element.scrollIntoView({ behavior: 'smooth' });
}
function MoveableModal() {
    $('.modal-dialog').draggable({
        handle: ".modal-header"
    });
    $('#myModal').on('shown.bs.modal', function () {
        $(".modal-header").css("cursor", "move");
    })

    $('.modal-dialog2').draggable({
        handle: ".modal-header"
    });
    $('#myModal2').on('shown.bs.modal', function () {
        $(".modal-header").css("cursor", "move");
    })

    $('#smsModal').on('shown.bs.modal', function () {
        $(".modal-header").css("cursor", "move");
    })
}
function status(cellvalue) {
    if (cellvalue == true)
        return "Active";
    else
        return "Disable";
};
function YesNo(cellvalue) {
    if (cellvalue == true)
        return "Yes";
    else
        return "No";
};
function Cancel(cellvalue) {
    if (cellvalue == true)
        return "Canceled";
    else
        return "Pending";
};
function enablestatus(cellvalue) {
    if (cellvalue == true)
        return "Enable";
    else
        return "Disable";
};
function statusDelete(cellvalue) {
    if (cellvalue == true)
        return "Deleted";
    else
        return "--";
};
function statusDefault(cellvalue) {
    if (cellvalue == true)
        return "Default";
    else
        return "Normal";
};

function IsDefault(cellvalue) {
    if (cellvalue == true)
        return "Yes";
    else
        return "No";
};

function IsHide(cellvalue) {
    if (cellvalue == true)
        return "Hide";
    else
        return "Show";
};

function isActiveError(cellvalue) {
    if (cellvalue == "Active")
        return "Active";
    else
        return "Disable <i class='fa fa-warning color-red'> </i>";
};

function ExpireDaysError(cellvalue) {
    if (cellvalue > 0)
        return cellvalue;
    else
        return cellvalue + " <i class='fa fa-warning color-yellow'> </i>";
};

function NewFactorTask(elem) {
    var fid = $(elem).attr("data-fid");
    var taskid = $(elem).attr("data-id");
    var note = $(elem).attr("data-note");
    var onlyTime = $(elem).attr("data-onlytime");

  
    myLoading('start');
    $.ajax({
        url: "/Task/_newTask",
        type: "get",
        data: { fid: fid, id: taskid, onlyNote: note, onlyTime: onlyTime  },
        success: function (result) {
         
            $("#modalBody").html(result);
            myLoading('stop');
            $("#myModal").modal("show");
        },
        error: function (result) {
            myLoading('stop');
            alert('Error... Please try again');
        }
    })
}

function DoneTask(elem) {
    Lobibox.prompt('area', {
        title: 'Please enter  task completion note',
        buttons: {
            ok: {
                text: 'Complete'
            },
            cancel: {
              
            },
        },
        multiline: true,
        attrs: {
            placeholder: "Completion Note...",
            rows: "5",

        },
        callback: function (date, type) {



            if (type === 'ok') {
                var tid = $(elem).attr("data-tid");
                var text = $(".lobibox-input").val();
                $.ajax({
                    url: "/Task/DoneTask/",
                    type: "get",
                    data: { id: tid, description: text },
                    success: function (msg) {
                        if (msg != null && msg.success) {
                            showMessage(msg.responseText, "success");
                            $("#myModal2").modal("hide");
                            $("#myModal").modal("hide");
                            ReloadTimeLine();
                         

                        }
                        else if (msg != null && !msg.success) {
                            $("#modalbox").waitMe("hide");
                            showMessage(msg.responseText, "error");
                        }
                    }
                })
            }

        }
    });





}

function AddTaskNote(elem) {
    Lobibox.prompt('area', {
        title: 'Please add note',
        multiline: true,
        attrs: {
            placeholder: "Add Note...",
            rows: "5",

        },
        callback: function (date, type) {



            if (type === 'ok') {
                var tid = $(elem).attr("data-id");
                var text = $(".lobibox-input").val();
                $.ajax({
                    url: "/Task/AddNote/",
                    type: "get",
                    data: { id: tid, description: text },
                    success: function (msg) {
                        if (msg != null && msg.success) {

                            ReloadTimeLine();
                            $("#myModal2").modal("hide");
                            $("#myModal").modal("hide");

                        }
                        else if (msg != null && !msg.success) {
                            showMessage(msg.responseText, "error");
                            $("#modalbox").waitMe("hide");

                        }
                    }
                })
            }

        }
    });





}

function ViewFactorTask(elem) {
    var fid = $(elem).attr("data-fid");
    var taskid = $(elem).attr("data-id");



    myLoading('start');
    $.ajax({
        url: "/Task/_taskDetails",
        type: "get",
        data: { fid: fid, id: taskid },
        success: function (result) {

            if (result != null && result.success == false) {
                showMessage(msg.responseText, "error");
                return; 
            }
            $("#modalBody").html(result);
            myLoading('stop');
            $("#myModal").modal("show");
        },
        error: function (result) {
            myLoading('stop');
            alert('Error... Please try again');
        }
    })
}
function NegativeError(cellvalue) {

    if (cellvalue == 10001)
        return '';
    else if (cellvalue > 0)
        return cellvalue;
    else if (cellvalue == 0)
        return cellvalue + " <i class='fa fa-warning color-yellow'> </i>";
    else
        return cellvalue + " <i class='fa fa-warning color-red'> </i>";
};
function Direction(cellvalue) {
    if (cellvalue == true)
        return "راست چین";
    else
        return "چپ چین";
};

function ShowAlert(Message, Type) {
    var retuenPM = "<div class=\"alert alert-" + Type + " margin-bottom-30\" style=\"text-align:left; display:normal;\">";
    retuenPM += "<button type =\"button\" class=\"close\" data-dismiss=\"alert\"><span aria-hidden=\"true\">×</span><span class=\"sr-only\">Close</span></button>";
    retuenPM += Message;
    retuenPM += "</div>";
    return retuenPM;
}

function showMessage(msg, status) {

    Lobibox.notify(status, {
        msg: msg,
        position: 'top right',
        delay: 1500,
    });

};

function showMessageBig(msg, status) {

    Lobibox.notify(status, {
        msg: msg,
        //   position: 'top center',
        size: 'large',
       
    });
}
function showMessageTop(msg, status, time = 4000) {
    $(".lobibox-close").click();
    Lobibox.notify(status, {
        msg: msg,
        position: 'bottom center',
        delay: time,
        icon: false,
        //  size:'large'
    });

};

function showMessage2(msg, status) {
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
//function PushNotification(msg, header,url) {
//    if (header == "") header = "Message from Glassma Llc.";
//    if (url == "") url = '/Admin/Index';
//    Push.create(header, {
//        body: msg,
//        icon: "/Content/glassma.png",
//        timeout: 50000,
//        onClick: function () {
//            window.location.href = url;
//        }
//    });
//}
function ShowTextToMessageBox(text, elem) {
    $(elem).html(text);
    $(elem).toggle("slow");;
}
function reloadGrid(reload) {
    if ($('#jqgrid').length != 0) {
        $("#jqgrid").setGridParam({ datatype: 'json' });
        $('#jqgrid').trigger('reloadGrid');
    }
    else if (reload) {
        setTimeout(function () {
            window.location.reload();
        }, 2000);
    }
};


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

function readURL(input) {


    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#displayImage').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
};

$("form#mainForm").submit(function (e) {
    e.preventDefault();
    //$(this).validate({ ignore: "" });
    //var formMain = $("#mainSection");
    //formMain.removeData('validator');
    //formMain.removeData('unobtrusiveValidation');
    //$.validator.unobtrusive.parse(formMain);
    //var validForm = true;

    //$(".tab-content div.tab-pane").each(function () {
    //    alert($(this).attr("id"))
    //    if ($(this).find(".ifSaveTranslation").is(":checked"))
    //    {
    //        //var $inputs = $(this).find("input");
    //        //$inputs.each(function () {
    //        //    if (!validator.element(this) && valid) {
    //        //        validForm = false;
    //        //        var liID = $(this).find(".ifSaveTranslation").attr("data-liID");
    //        //            $("#" + liID + " a").css("color", "#EA392A");
    //        //    }
    //        //});
    //        //var tabID = $(this).attr("data-tabID");
    //        var formTr = $(this);

    //        formTr.removeData('validator');
    //        formTr.removeData('unobtrusiveValidation');
    //        $.validator.unobtrusive.parse(formTr);
    //        //$(formTr).validate({
    //        //    ignore: "input[type='text']:disabled"
    //        //});

    //        if(!$(formTr).valid())
    //        {
    //            alert("not")
    //            validForm = false;
    //            var liID = $(this).find(".ifSaveTranslation").attr("data-liID");
    //            $("#" + liID + " a").css("color", "#EA392A");
    //        }
    //    }
    //})


    //if ($(formMain).valid() & validForm) 

    {

        if ($("form#mainForm").valid() == false) {
            return false;
        }

        var btn = $("#saveBtn");
        btn.button('loading')
        if (typeof (CKEDITOR) !== "undefined") {
            for (instance in CKEDITOR.instances) {
                //  alert(instance)

                CKEDITOR.instances[instance].updateElement();
                $(instance).val();
            }
        }
        var data = $(this).serialize();
        var url = $(this).attr("action");

        var language = $(this).attr("language");
        var WS = $(this).attr("WS");

        $.ajax(
            {
                url: url + "?language=" + language + "&WS=" + WS,
                type: "post",

                data: data,

                success: function (msg) {

                    if (msg != null && msg.success) {

                        showMessage(msg.responseText, "success");
                        $("#myModal").modal("hide");
                        reloadGrid();
                        btn.button('reset')
                    }
                    else if (msg != null && !msg.success) {
                        showMessage(msg.responseText, "error");
                        btn.button('reset')

                        //_this.log('Form message', response);
                    }


                },
                error: function (xhr, ajaxOptions, thrownError) {
                    //  showMessage(xhr.responseText, "error");
                    alert('Error... Please try again');
                }
            })

    }
})
function showAddDialog(controller, action) {
    myLoading('start');
    $.ajax({
        url: "/" + controller + "/" + action,
        type: "get",
        success: function (result) {
            $("#modalBody").html(result);
            myLoading('stop');
            $("#myModal").modal("show");
        },
        error: function (result) {
            myLoading('stop');
            alert('Error... Please try again');
        }
    })
};


function AddDialogWorkScheduling(url) {

    myLoading('start');
    $.ajax({
        url: url,
        type: "get",
        success: function (result) {
            $("#modalBody5").html(result);
            myLoading('stop');
            $("#myModal5").modal("show");
        },
        error: function (result) {
            myLoading('stop');
            alert('Error... please try again.');
        }
    })
};
function showEditDialog(controller, action) {
    var selRowId = $("#jqgrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("Please select a record", "error");
        return;
    }
    else {
        myLoading('start');
        $.ajax({
            url: "/" + controller + "/" + action,
            type: "get",
            data: { id: selRowId },
            success: function (result) {
                $("#modalBody").html(result);
                myLoading('stop');
                $("#myModal").modal("show");
            },
            error: function (result) {
                myLoading('stop');
                alert('Error... Please try again');
            }
        })
    }
};
function showDeleteRow(controller, action) {
    var selRowId = $("#jqgrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("Please select a record", "error");
        return;
    }
    Lobibox.confirm({
        msg: "Do you want to delete record ?",
        callback: function ($this, type, ev) {
            if (type == "yes") {
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
                    }
                })
            }
        }
    });


}
function showDeleteRowDoubleQuestion(controller, action) {
    var selRowId = $("#jqgrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("Please select a record", "error");
        return;
    }
    Lobibox.confirm({
        msg: "Do you want to delete record ?",
        callback: function ($this, type, ev) {
            if (type == "yes") {


                Lobibox.confirm({
                    msg: "If you delete this record all expense related with record will be 'None', are you sure ??",
                    callback: function ($this, type, ev) {
                        if (type == "yes") {
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
                                }
                            })

                        }
                    }
                });

            }
        }
    });


}
function showDeleteListUser(controller, action) {
    var dataToSend = new Array();
    var dataToSend = $('#jqgrid').getGridParam('selarrrow').join().split(',');
    if (dataToSend == "") {
        showMessage("Please select a record", "error");
        return false;
        // dataToSend = JSON.stringify($('#jqGrid').jqGrid('getDataIDs')).slice(0, -2).substr(2).split('","');//Select All Row
    }

    if (confirm('Do you want to delete record ?') == false) {
        return false;
    }
    if (confirm('If you delete user all user data will delete, are you sure ?') == false) {
        return false;
    }
    $.ajax({
        url: "/" + controller + "/" + action + "",
        type: "post",
        data: { List: dataToSend },
        success: function (msg) {
            if (msg != null && msg.success) {
                showMessage(msg.responseText, "success");
                reloadGrid();
            }
            else if (msg != null && !msg.success) {
                showMessage(msg.responseText, "error");
            }
        }
    })



}

function showDeleteList(controller, action) {
    var dataToSend = new Array();
    var dataToSend = $('#jqgrid').getGridParam('selarrrow').join().split(',');
    if (dataToSend == "") {
        showMessage("Please select a record", "error");
        return false;
        // dataToSend = JSON.stringify($('#jqGrid').jqGrid('getDataIDs')).slice(0, -2).substr(2).split('","');//Select All Row
    }


    if (confirm('Do you want to delete records?')) {
        $.ajax({
            url: "/" + controller + "/" + action + "",
            type: "post",
            data: { List: dataToSend },
            success: function (msg) {
                if (msg != null && msg.success) {
                    showMessage(msg.responseText, "success");
                    reloadGrid();
                }
                else if (msg != null && !msg.success) {
                    showMessage(msg.responseText, "error");
                }
            }
        })
    }


}
function showDeleteUser(controller, action) {
    var selRowId = $("#jqgrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("Please select a record", "error");
        return;
    }

    Lobibox.confirm({
        msg: "Do you want to delete record ?",
        callback: function ($this, type, ev) {
            if (type == "yes") {

                Lobibox.confirm({
                    msg: "If you delete user all user data will delete, are you sure ?",
                    callback: function ($this, type, ev) {
                        if (type == "yes") {


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
                                error: function () {
                                    alert('Error... please try again');
                                }

                            })
                        }
                    }
                });
            }
        }
    });






};




function showAddDialogUrl(Url) {
    myLoading('start');
    $.ajax({
        url: Url,
        type: "get",
        success: function (result) {
            $("#modalBody").html(result);
            myLoading('stop');
            $("#myModal").modal("show");
        },
        error: function (result) {
            myLoading('stop');
            alert('Error... please try again.');
        }
    })
};
function showEditDialogUrl(Url) {
    var selRowId = $("#jqgrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("Please select a record", "error");
        return;
    }
    else {
        myLoading('start');
        $.ajax({
            url: Url,
            type: "get",
            data: { id: selRowId },
            success: function (result) {


                if (result.success != null) {
                    if (result.success) {
                        waitingDialog.hide();
                        showMessage(result.responseText, "success");
                    }
                    else if (!result.success) {
                        waitingDialog.hide();
                        showMessage(result.responseText, "error");
                    }
                    myLoading('stop');
                }
                else {
                    $("#modalBody").html(result);
                    waitingDialog.hide();
                    $("#myModal").modal("show");
                    myLoading('stop');
                }

            },
            error: function (result) {
                myLoading('stop');
                alert('Error... please try again.');
            }
        })
    }
};
function showEditDialogUrlNoId(Url) {


  //  myLoading('start');
    $.ajax({
        url: Url,
        type: "get",
        success: function (result) {


            if (result.success != null) {
                if (result.success) {
                    waitingDialog.hide();
                    showMessage(result.responseText, "success");

                }
                else if (!result.success) {
                    waitingDialog.hide();
                    showMessage(result.responseText, "error");
                }
            }
            else {
                $("#modalBody").html(result);
                waitingDialog.hide();
                $("#myModal").modal("show");
            }

        },
        error: function (result) {
         //  myLoading('stop');
            alert('Error... please try again.');
        }
    })

};

function showDeleteRowUrl(Url) {
    var selRowId = $("#jqgrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("Please select a record", "error");
        return;
    }
    Lobibox.confirm({
        msg: "Do you want to delete record ?",
        callback: function ($this, type, ev) {
            if (type == "yes") {
                $.ajax({
                    url: Url,
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
                    }
                })
            }
        }
    });


}
function showDeleteRowUrlNoId(Url) {

    Lobibox.confirm({
        msg: "Do you want to delete record ?",
        callback: function ($this, type, ev) {
            if (type == "yes") {
                $.ajax({
                    url: Url,
                    type: "get",
                    success: function (msg) {
                        if (msg != null && msg.success) {
                            showMessage(msg.responseText, "success");
                            reloadGrid();
                        }
                        else if (msg != null && !msg.success) {
                            showMessage(msg.responseText, "error");
                        }
                    }
                })
            }
        }
    });


}
function ConfirmEstimateAppointment2(elem) {
    var fid = $(elem).attr("data-id");
    ConfitmEsApnt(fid, elem);
}
function ConfirmInstallAppointment2(elem) {
    var fid = $(elem).attr("data-id");
    ConfitmInstallApnt(fid, elem);
}

function ConfitmInstallApnt(fid, elem, url) {

    Lobibox.confirm({
        msg: "Do you want to confirm appointment ?",
        callback: function ($this, type, ev) {
            if (type == "yes") {
                $(elem).waitMe({});
                $.ajax({
                    url: "/Factor/_confirmApnt",
                    type: "get",
                    data: { id: fid, type: 'installation' },
                    success: function (msg) {
                        if (msg != null && msg.success) {
                            showMessage(msg.responseText, "success");
                            $(elem).waitMe("hide");
                            if (url == null) {
                                setTimeout(function () {
                                    window.location.reload();
                                }, 1000);
                            }
                            else {
                                window.location.href = url;
                            }
                        }
                        else if (msg != null && !msg.success) {
                            showMessage(msg.responseText, "error");
                            $(elem).waitMe("hide");
                        }
                    }
                })
            }
        }
    });
}

function ConfitmEsApnt(fid, elem, url) {

    Lobibox.confirm({
        msg: "Do you want to confirm appointment ?",
        callback: function ($this, type, ev) {
            if (type == "yes") {
                $(elem).waitMe({});
                $.ajax({
                    url: "/Factor/_confirmApnt",
                    type: "get",
                    data: { id: fid, type: 'estimation' },
                    success: function (msg) {
                        if (msg != null && msg.success) {
                            showMessage(msg.responseText, "success");
                            $(elem).waitMe("hide");
                            if (url == null) {
                                setTimeout(function () {
                                    window.location.reload();
                                }, 1000);
                            }
                            else {
                                window.location.href = url;
                            }
                        }
                        else if (msg != null && !msg.success) {
                            showMessage(msg.responseText, "error");
                            $(elem).waitMe("hide");
                        }
                    }
                })
            }
        }
    });
}
function showDeleteListUrl(Url) {
    var dataToSend = new Array();
    var dataToSend = $('#jqgrid').getGridParam('selarrrow').join().split(',');
    if (dataToSend == "") {
        showMessage("Please select a record", "error");
        return false;
        // dataToSend = JSON.stringify($('#jqGrid').jqGrid('getDataIDs')).slice(0, -2).substr(2).split('","');//Select All Row
    }


    if (confirm('Do you want to delete records?')) {
        $.ajax({
            url: Url,
            type: "post",
            data: { List: dataToSend },
            success: function (msg) {
                if (msg != null && msg.success) {
                    showMessage(msg.responseText, "success");
                    reloadGrid();
                }
                else if (msg != null && !msg.success) {
                    showMessage(msg.responseText, "error");
                }
            }
        })
    }


}
function showDeleteUserUrl(Url) {
    var selRowId = $("#jqgrid").getGridParam("selrow");
    if (selRowId == null) {
        showMessage("Please select a record.", "error");
        return;
    }
    if (confirm('Do you want to delete record ?') == false) {
        return false;
    }
    if (confirm('If you delete user all user data will delete, are you sure ?') == false) {
        return false;
    }
    $.ajax({
        url: Url,
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
        error: function () {
            alert('Error... please try again');
        }

    })



};


function AddEditFormUrl(form, Url, mode) {

    modalBody = $("#modalBody").html();
    $("form#" + form + "").submit(function (e) {

        e.preventDefault();
        if ($("form#" + form + "").valid()) {
            var btn = $("#saveBtn");
            btn.button('loading');
            var data = $("form#" + form + "").serialize();
            $.ajax(
                {
                    url: Url,
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
                            showMessage(msg.responseText, "error");
                        }
                    }
                });
        }
    });
}

function SearchFunction(controller, action) {
    $('#Search').keypress(function (e) {
        var key = e.which;
        if (key == 13) {
            $('#btnSearch').click();
            return false;
        }
    });

    $("#btnSearch").click(function () {
        var data = $("#Search").val().trim();
        jQuery("#jqgrid").jqGrid('setGridParam', {
            url: "/" + controller + "/" + action + "?Search=" + data
            , datatype: 'json', page: 1
        });
        jQuery("#jqgrid").trigger("reloadGrid");
    });
}

function ChangeStatusUrl(Url) {
    $("#status_filter").change(function () {
        jQuery("#jqgrid").jqGrid('setGridParam', {
            url: Url + "?Status=" + $(this).val()
            , datatype: 'json', page: 1
        });
        jQuery("#jqgrid").trigger("reloadGrid");
    });
}
function SearchFunctionUrl(Url) {
    $('#Search').keypress(function (e) {
        var key = e.which;
        if (key == 13) {
            $('#btnSearch').click();
            return false;
        }
    });

    $("#btnSearch").click(function () {
        var data = $("#Search").val().trim();
        jQuery("#jqgrid").jqGrid('setGridParam', {
            url: Url + "?Search=" + data + "&Status=" + $("#status-filter").val()
            , datatype: 'json', page: 1
        });
        jQuery("#jqgrid").trigger("reloadGrid");
    });
}
function SearchFunctionUrlByParameter(Url) {
    $('#Search').keypress(function (e) {
        var key = e.which;
        if (key == 13) {
            $('#btnSearch').click();
            return false;
        }
    });

    $("#btnSearch").click(function () {
        var data = $("#Search").val().trim();
        jQuery("#jqgrid").jqGrid('setGridParam', {
            url: Url + "&Search=" + data + "&Status=" + $("#status-filter").val()
            , datatype: 'json', page: 1
        });
        jQuery("#jqgrid").trigger("reloadGrid");
    });
}
function myLoading(action) {
    myLoadingWaitMe(action);
    return;
    if (action == 'start') {
        $('body').loading({
            theme: 'dark',
            message: 'Loading....'
        });
    }
    else if (action == 'stop') {
        $('body').loading('stop');
    }
};

function myLoadingWaitMe(action) {
    if (action == 'start') {
        $('body').waitMe({});
    }
    else if (action == 'stop') {
        $("body").waitMe("hide");

    }
};
function getLocationDes(ip, Url) {
    if (ip == null) {
        showMessage("Error to get ip!", "error");
        return;
    }
    else {
        myLoading('start');
        $.ajax({
            url: Url,
            type: "post",
            data: { ip: ip },
            success: function (result) {
                $("#modalBody").html(result);
                myLoading('stop');
                $("#myModal").modal("show");
            },
            error: function (result) {
                myLoading('stop');
                alert('Error... please try again.');
            }
        })
    }
}


/////////////////////////////////////////////


// This is a sample function which is called when a file is selected in CKFinder.

function ChoosePicture() { }
function ShowPicture(elem, location) {

    var WebuiPopovers = $(elem).prev().webuiPopover({
        title: 'No Image',
        direction: 'rtl',
        trigger: 'hover',
        animation: 'pop',
        placement: location,
        type: 'html',
        cache: false,
        content: function () { return '<img src="' + $(elem).attr("data-image") + '" style="width:200px;height:200px;" />'; },

    });

};
function BrowseServer(elem) {
    PictureSelect = $(elem).parent().prev();
    // You can use the "CKFinder" class to render CKFinder in a page:
    var finder = new CKFinder();
    finder.basePath = '../';	// The path for the installation of CKFinder (default = "/ckfinder/").
    finder.selectActionFunction = SetFileField;
    finder.popup();
}

function BrowseServer2(elem) {
    PictureSelect = $(elem).parent().prev();
    // You can use the "CKFinder" class to render CKFinder in a page:
    var finder = new CKFinder();
    finder.basePath = '../';	// The path for the installation of CKFinder (default = "/ckfinder/").
    finder.selectActionFunction = SetFileField2;
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
function AddEditForm(form, controller, action, mode) {

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

                            if ($("#closeModal").length == 0) $("#myModal").modal("hide");//If closeModal not exist
                            reloadGrid();


                            if ($("#closeModal").is(':checked')) $("#myModal").modal("hide");
                            else if (mode == "add") { $("#modalBody").html(modalBody); $('#closeModal').attr('checked', false); }

                        }
                        else if (msg != null && !msg.success) {

                            showMessage(msg.responseText, "error");
                        }
                    }
                });
        }
    });
}

function AddEditUploadFile(form, controller, action, mode, InStartJob) {

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

                                    alert('Error upload image... please try again');
                                },
                                complete: function (data) {
                                    btn.button('reset');
                                    showMessage(msg.responseText, "success");
                                    if (InStartJob == true)
                                        window.location.href = "/Factor/Add/" + msg.UserID;
                                    // reloadGrid();
                                    if ($("#closeModal").is(':checked')) $("#myModal").modal("hide");
                                    else if (mode == "add") {
                                        $("#modalBody").html(modalBody); $('#closeModal').attr('checked', false);
                                    }
                                    Update_ProjectInfo();
                                }
                            });

                            //------------

                        }
                        else if (msg != null && !msg.success) {
                            btn.button('reset');
                            showMessage(msg.responseText, "error");
                        }
                    },
                    error: function (msg) {
                        btn.button('reset');
                        alert("Error... please try again");
                    }
                });
        }
    });
}


function FormSubmit_Translation() {
    $("form").submit(function (e) {
        for (instance in CKEDITOR.instances) {
            CKEDITOR.instances[instance].updateElement();
        }
    })

    $("form#mainForm").submit(function (e) {

        e.preventDefault();


        {

            if ($("form#mainForm").valid() == false) {
                return false;
            }
            var btn = $("#saveBtn");
            btn.button('loading')
            var data = $(this).serialize();
            var url = $(this).attr("action");
            alert(data);
            if (typeof (CKEDITOR) !== "undefined") {
                for (instance in CKEDITOR.instances) {
                    CKEDITOR.instances[instance].updateElement();
                }
            }
            $.ajax(
                {
                    url: url,
                    type: "post",
                    success: function (msg) {
                        if (msg != null && msg.success) {
                            showMessage(msg.responseText, "success");
                            $("#myModal").modal("hide");
                            reloadGrid();
                            btn.button('reset')
                        }
                        else if (msg != null && !msg.success) {
                            showMessage(msg.responseText, "error");
                            btn.button('reset');
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        //  alert(xhr.responseText);
                    }
                })

        }
    })


    $('.ifSaveTranslation').each(function () {

        if ($(this).is(":checked")) {
            if ($(this).attr("data-languageID") == '@ViewBag.currentLanguageID')
                $(this).attr("onclick", "return false");
            var tabID = $(this).attr("data-tabID");

            $("#" + tabID + " *").each(function () {
                $(this).removeAttr("readonly");
                if ($(this).hasClass("editor")) {
                    CKEDITOR.replace($(this).attr('id'), { readOnly: false });
                }
            })
            var liID = $(this).attr("data-liID");
            $("#" + liID + " a").css("color", "#12B447");
        }
        else {
            var tabID = $(this).attr("data-tabID");
            $("#" + tabID + " *").each(function () {
                $(this).attr("readonly", true);
                if ($(this).hasClass("editor")) {
                    CKEDITOR.replace($(this).attr('id'), { readOnly: true });
                }
            })
            $(this).removeAttr("readonly");
            var liID = $(this).attr("data-liID");
            $("#" + liID + " a").css("color", "#555");
        }
    })
    $(".ifSaveTranslation").change(function () {
        if ($(this).is(":checked")) {
            var tabID = $(this).attr("data-tabID");
            //alert($("#"+tabID).find("form").attr("id"))
            //alert($(tabID+" form").attr("id"))
            $("#" + tabID + " *").each(function () {
                $(this).removeAttr("readonly");
                if ($(this).hasClass("editor"))
                    CKEDITOR.instances[$(this).attr("id")].setReadOnly(false);
            })
            var liID = $(this).attr("data-liID");
            $("#" + liID + " a").css("color", "#12B447");

        }
        else {
            var tabID = $(this).attr("data-tabID");
            $("#" + tabID + " *").each(function () {
                $(this).attr("readonly", true);
                if ($(this).hasClass("editor"))
                    CKEDITOR.instances[$(this).attr("id")].setReadOnly(true);
            })
            var liID = $(this).attr("data-liID");
            $("#" + liID + " a").css("color", "#555");
            alert("بعد از ثبت ترجمه مورد نظر حذف می شود!")
        }

    })

    $(".nav-tabs li").click(function () {

        if ($(".tab-pane.active .ifSaveTranslation").is(":checked")) {

            if ($("form#mainForm").valid() == false) {
                return false;
            }
        }
    })
}

function printAllData(action, PrintDataUrl) {//"/Report/PrintData"
    //jQuery("#jqGrid").jqGrid('getRowData'); <= current page 
    //$("#jqGrid").jqGrid('getGridParam', 'data'); <= All data 


    //-----------------------------------------------------Get Json Data
    //var dataToSend = "[";
    //var selRowId = $('#jqGrid').getGridParam('selarrrow').join();
    //var c = 0;
    //selRowId.split(',').forEach(function (item) {
    //    dataToSend += JSON.stringify($("#jqGrid").jqGrid("getRowData", item)) + ",";
    //    c++;
    //});
    //dataToSend = dataToSend.slice(0, -1);
    //dataToSend +="]";
    //if (dataToSend.trim() == "[{}]") {
    //    dataToSend = JSON.stringify($("#jqGrid").jqGrid('getGridParam', 'data'));
    //}





    //----------------------------------------------------------
    var dataToSend = new Array();
    var dataToSend = $('#jqgrid').getGridParam('selarrrow').join().split(',');

    if (dataToSend == "") {

        dataToSend = JSON.stringify($('#jqgrid').jqGrid('getDataIDs')).slice(0, -2).substr(2).split('","');
    }

    // return;
    $.ajax({
        url: "/Report/" + action + "",
        type: 'POST',
        data: { List: dataToSend },
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
            showMessage("Error... please try again", "error");
        }
    });
};

function printAllDataUrl(Url, printInTab) {


    //----------------------------------------------------------
    var dataToSend = new Array();
    var dataToSend = $('#jqgrid').getGridParam('selarrrow').join().split(',');
    if (dataToSend == "") {

        dataToSend = JSON.stringify($('#jqgrid').jqGrid('getDataIDs')).slice(0, -2).substr(2).split('","');
    }

    // return;
    $.ajax({
        url: Url,
        type: 'POST',
        data: { List: dataToSend },
        dataType: 'json',
        success: function (msg) {

            if (msg != null && msg.success) {
                showMessage(msg.responseText, "success");
                if (printInTab) {
                    var win = window.open('/Report/PrintData', '_blank');
                    if (win) {
                        //Browser has allowed it to be opened
                        win.focus();
                    } else {
                        //Browser has blocked it
                        alert('Please allow popups for this website');
                    }
                }
                else {
                    window.location.href = "/Report/PrintData";
                }

            }
            else if (msg != null && !msg.success) {
                showMessage(msg.responseText, "error");
            }
        },
        error: function (msg) {
            showMessage("Error... please try again.", "error");
        }
    });
};


function printDataUrl(Url, printInTab) {
    //}

    //----------------------------------------------------------
    var dataToSend = new Array();

    // return;
    $.ajax({
        url: Url,
        type: 'POST',
        data: { List: dataToSend },
        dataType: 'json',
        success: function (msg) {

            if (msg != null && msg.success) {
                showMessage(msg.responseText, "success");
                if (printInTab) {
                    var win = window.open('/Report/PrintData', '_blank');
                    if (win) {
                        //Browser has allowed it to be opened
                        win.focus();
                    } else {
                        //Browser has blocked it
                        alert('Please allow popups for this website');
                    }
                }
                else {
                    window.location.href = "/Report/PrintData";
                }

            }
            else if (msg != null && !msg.success) {
                showMessage(msg.responseText, "error");
            }
        },
        error: function (msg) {
            showMessage("Error... please try again", "error");
        }
    });
};


function ContextMenuBase(e) {
    e.preventDefault();
    $.contextMenu({
        selector: '.pointer',
        trigger: 'left',
        zIndex: 10000,
        items: {
            "Add": { name: "Add", icon: "add", className: 'icon-color-success', callback: function (key, options) { AddDialog(); } },
            "Edit": { name: "Edit", icon: "edit", className: 'icon-color-warning', callback: function (key, options) { EditDialog(); } },
            "Delete": { name: "Delete", icon: "delete", className: 'icon-color-danger', callback: function (key, options) { DeleteRow(); } },
            "Refresh": { name: "Refresh", icon: "fa-refresh", className: 'icon-color-primary', callback: function (key, options) { reloadGrid(); } },

        },
        events: {
            hide: function (opt) {
                $(".pointer").contextMenu('destroy');
            }
        },

    });
}

function ContextMenuBaseList(e) {
    e.preventDefault();
    $.contextMenu({
        selector: '.pointer',
        trigger: 'left',
        zIndex: 10000,
        items: {
            "Add": { name: "Add", icon: "add", className: 'icon-color-success', callback: function (key, options) { AddDialog(); } },
            "Edit": { name: "Edit", icon: "edit", className: 'icon-color-warning', callback: function (key, options) { EditDialog(); } },
            "Delete": { name: "Delete", icon: "delete", className: 'icon-color-danger', callback: function (key, options) { DeleteList(); } },
            "Refresh": { name: "Refresh", icon: "fa-refresh", className: 'icon-color-primary', callback: function (key, options) { reloadGrid(); } },

        },
        events: {
            hide: function (opt) {
                $(".pointer").contextMenu('destroy');
            }
        },

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
                showMessage('Error... please try again', "error");
            }
        });
}
function deleteImageLibrary(elem) {
    var Id = $(elem).attr("data-ID");
    $.ajax(
        {
            url: "/" + "Library" + "/" + "DeleteImageLibrary",
            type: "post",
            data: { id: Id },
            success: function (msg) {

                if (msg != null && msg.success) {
                    $("#displayImage").attr("src", "/Content/default.jpg");
                    $("#UploadImage").val(null);
                }
                else if (msg != null && !msg.success) {
                    showMessage(msg.responseText, "error");
                }
            },
            error: function (msg) {
                showMessage('Error... please try again', "error");
            }
        });
}
function DisplayPhotoInJqGrid(cellvalue, options, rowObject) {
    var image = new Image();
    image.src = cellvalue;
    if (image.width == 0) {
        cellvalue = "/Content/default.jpg"
    }
    return "<img src='" + cellvalue + "' class='UserProfileImage img-responsive imageingrid' width=\"60\" height=\"60\" alt='تصویر'/>";
}

function DisplayImageInJqGrid(cellvalue, options, rowObject) {
    var image = rowObject["Image"];
    if (image == '0')
        return '';
    return "<img alt=\"image‌\" class='UserProfileImage' src=\"/Content/Files/ProfileImages/" + (image != null ? image : "default-image.jpg") + "\" class=\"\"  width=\"25\" height=\"25\">";
};

function DisplaySignatureInJqGrid(cellvalue, options, rowObject) {
    var image = rowObject["ElectronicSignature"];
    if (image == '0')
        return '';

    return "<img  class='UserProfileImage' src=\"" + image + "\" class=\"\"  width=\"25\" height=\"25\">";
};
function ChangeCheckBox(isActive, Content) {
    if (isActive.is(":checked")) {
        Content.css("display", "inline");
    }
    else {
        Content.css("display", "none");
    }

    isActive.change(function () {
        if (this.checked) {
            Content.css("display", "inline");
        }
        else {
            Content.css("display", "none");
        }
    });
}
function jqGridloadComplete(jqgrid) {
    var WebuiPopovers = $(jqgrid).find("td .UserProfileImage").webuiPopover({
        direction: 'rtl',
        trigger: 'hover',
        animation: 'pop',
        placement: 'top-left',
        type: 'html',
        cache: false,
        content: function () { return '<img src="' + $(this).attr('src') + '" style="width:125px;height:125px;" />'; },

    });
}

function jqGridPagationServerSide($this, data) {
    $this.setGridParam({ datatype: 'local' });

    $this.jqGrid('setGridParam', {
        page: data.page,
        records: data.records,
        lastpage: data.total
    });


    if ($this.jqGrid('getGridParam', 'sortname') !== '') {
        $this.triggerHandler('reloadGrid');
    }

    //https://stackoverflow.com/questions/9030302

}

function UserName(cellvalue, options, rowObject) {
    if (cellvalue == null)
        return "";
    else
        return "<a class='btn btn-xs btn-default' href='javascript:;' onclick='UserNameInfo(\"" + cellvalue + "\")'>" + cellvalue + "</a>";

}
function UserNameInfo(un) {
    myLoading('start');

    $.ajax({
        url: '/Base/_UserNameInfo',
        type: "get",
        data: { id: un },
        success: function (result) {
            $("#modalBody").html(result).removeClass("modal-lg");
            myLoading('stop');
            $("#myModal").modal("show");
        },
        error: function (e) {
            myLoading('stop');
            showMessage("Error... please try again", 'error');
        }
    })
}

$(document).ready(function () {


    $(".onlynumber").keypress(function (e) {

        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57) && e.which != 45) {
            return false;
        }
    })

});

