/*!
 * AjaxJQueryHelpers v0.0.3 (https://github.com/Hatem-Hamad/code_libraries/blob/master/JavaScript/AjaxJQueryHelpers.js)
 * 2015 Hatem Hamad.
 * Github : (https://github.com/Hatem-Hamad)
 * LinkedIn : (https://www.linkedin.com/in/hatemhamad)
 */


//creates then removes a Bootsrap alert div inside a given div where type : warning , success ...
//using a good library for alerts called "alertify"
$.makeAlertMessage = function (div_to_alert_in, type, message) {

    if (type == 'success')
        alertify.success("<strong>" + type + "</strong><p> " + message + " </p>");
    else
        alertify.error("<strong>" + type + "</strong><p> " + message + " </p>");
    //$(div_to_alert_in).append($("<div class='alert-message alert-" + type + " alert-dismissible fade in' role='alert' data-alert>"
    //    + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
    //    + "<strong>" + type + "</strong><p> " + message + " </p></div>"));
    //$(".alert-message").delay(2000).fadeOut("slow", function () { $(this).remove(); });
}

$.AJAX_to_action = function (Type, URL, Data, onsuccess_func_takes_dataparam, alert_div) {
    $.ajax({
        type: Type,
        url: URL,
        data: Data,
        success: function (data) {
            //success
            if ((data.success !== undefined && data.success !== null && data.success) || data.errorMessage === undefined) {
                $.makeAlertMessage(alert_div, "success", "Done !");
                onsuccess_func_takes_dataparam(data);

            }
            else {
                $.makeAlertMessage(alert_div, "warning", data.errorMessage);
            }
        },
        failure: function (data) {
            debugger
        },
    });
};