function HeartBeat(Min,Url) {
    return false;
        $.ajax({
            url: Url,
            type: "get",
            async:false,
            success: function (msg) {
               // if (msg != null && msg.success) {
               //  //  alert(msg.responseText);
               // }
               // else if (msg != null && !msg.success) {
               ////   alert(msg.responseText);
               // }
            }
        })

}

function ChangePageSize(Url) {

    $("#mobileMenuBtn").click(function () {
        $.ajax({
            url: Url,
            type: "get",
            //success: function (msg) {
            //}
        })
    })



}