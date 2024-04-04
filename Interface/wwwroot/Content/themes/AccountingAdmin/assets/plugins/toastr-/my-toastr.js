$(document).ready(function () {

    function showMessage(msg, status) {
        if (status == "success") {
            if (typeof toastr != 'undefined')
                toastr.success(msg);
            else alert(msg);
        }
        else if (status == "error") {
            if (typeof toastr != 'undefined')
                toastr.error(msg);
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
    }
});