/*!
 * AjaxJQueryHelpers v0.0.1 (http://getbootstrap.com)
 * 2015 Hatem Hamad.
 * Github : (https://github.com/Hatem-Hamad)
 * LinkedIn : (https://www.linkedin.com/in/hatemhamad)
 */


//creates then removes a Bootsrap alert div inside a given div where type : warning , success ...
$.makeAlertMessage = function(div_to_alert_in,type, message) {
    $(div_to_alert_in).append($("<div class='alert-message alert-" + type + " alert-dismissible fade in' role='alert' data-alert>"
        + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "<strong>"+type+"</strong><p> " + message + " </p></div>"));
    $(".alert-message").delay(2000).fadeOut("slow", function () { $(this).remove(); });
}

//send an ajax request to the given URL ,then excute the onsuccess_func,and alert with result from the server
$.AJAX_to_action = function (Type, URL, Data, onsuccess_func_takes_dataparam,alert_div) {
    $.ajax({
        type: Type,
        url: URL,
        data: Data,
        success: function (data) {
            //success
            if (data.success === undefined || data.success === null)
            {
                $.makeAlertMessage(alert_div, "success", "Done !");
                onsuccess_func_takes_dataparam(data);
                
            }
            else
            {
                $.makeAlertMessage(alert_div, "warning", data.errorMessage);
            }
        },
        failure: function (data) {
            debugger
        },
    });
};
