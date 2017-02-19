$(document).ready(function () {
    //////////////////////////////////////Form Names Unique//////////////////////////////////////////////////////
    //Options for typing watch
    var optionsTop = {
        callback: function (value) { checkname(value,window.location.pathname) },
        wait: 1000,
        highlight: true,
        captureLength: 0
    }

    //When User has done typing
    $('.NameWatch').typeWatch(optionsTop);

    //Checks with the Controller to see if the name entered is unique
    function checkname(input, form) {
        if(form.includes("Location")){
            form = "Location";
        }
        else if (form.includes("Event")) {
            form = "Event";
        }
        $.ajax({
            url: "/Tournament/doesNameExist",
            dataType: 'json',
            type: "POST",
            data: { Name: input, Form: form },
            context: document.body
        }).done(function (result) {
            if (form == "Location") {
                if (result == true) {
                    $('.LocationName span').text(" Name already exists");
                }
            }
            else if (form = "Event") {
                if (result == true) {
                    $('.EventName span').replaceWith(" Name already exists");
                }
            }
        });
    }
    //////////////////////////////////////End Form Names Unique//////////////////////////////////////////////////////
    //////////////////////////////////////Event Form Date selection//////////////////////////////////////////////////////
    $('#StartTime').datetimepicker({
        format: 'dd-mm-yyyy hh:ii',
        todayBtn: true,
        startDate: Date.now()
    });
    $('#EndTime').datetimepicker({
        format: 'dd-mm-yyyy hh:ii',
        todayBtn: true,
        startDate: Date.now()
    });
    //////////////////////////////////////End Event Form Date selection//////////////////////////////////////////////////////
}); //Document ready