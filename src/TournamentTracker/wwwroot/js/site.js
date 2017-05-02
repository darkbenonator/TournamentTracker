//////////////Variables////////////////////////
var EventTable;
//////////////End Variables ///////////////////
$(document).ready(function () {
    //////////////////////////////////////EventsDataTables//////////////////////////////////////////////////////
    if (window.location.pathname === '/tournament' || window.location.pathname === '/tournament/') {
        ///columns of the datatable
        var columns = [
            { "data": "eventName" },
            { "data": "locationName" },
            { "data": "locationCity" },
            { "data": "startTime" },
            { "data": "endTime" },
            { "data": "description" },
            {
                "data": null,
                "orderable": false,
                "fnCreatedCell": function (nTd, sData, oData, iRow, iCol) {
                    $(nTd).html("");
                    if (oData.eventOrganiser === UserID) {
                        $(nTd).append("<a href='tournament/EditEvent?EventID=" + oData.eventID + "'>Edit Event</a><br>");
                    }
                    else {
                        if (oData.signedUp === true) {
                            $(nTd).append("<a href='tournament/UnsubscribeToEvent?EventID=" + oData.eventID + "'>Leave Event</a><br>");
                        }
                        else {
                            $(nTd).append("<a href='tournament/SignUpToEvent?EventID=" + oData.eventID + "'>Sign Up</a><br>");
                        }
                    }
                    $(nTd).append("<a href='tournament/EventDetails?EventID=" + oData.eventID + "'>Event Details</a><br>");
                }
            }
        ];
        //Sets the buttons if they are the owner or not
        $('#EventsTable').DataTable({
            data: EventTableData,
            order: [[3, "asc"], [1, "asc"]],
            responsive: true,
            columns: columns
        });
    }
    //////////////////////////////////////EndEventsDataTables//////////////////////////////////////////////////////
    //////////////////////////////////////Form Names Unique//////////////////////////////////////////////////////
    //Options for typing watch
    var optionsTop = {
        callback: function (value) { checkname(value, window.location.pathname); },
        wait: 1000,
        highlight: true,
        captureLength: 0
    };

    //When User has done typing
    $('.NameWatch').typeWatch(optionsTop);

    //Checks with the Controller to see if the name entered is unique
    function checkname(input, form) {
        if (form.includes("Location")) {
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
            if (form === "Location") {
                if (result === true) {
                    $('.LocationName span').text(" Name already exists");
                }
            }
            else if (form === "Event") {
                if (result === true) {
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
    //////////////////////////////////////Event Add&Remove Player//////////////////////////////////////////////////////////
    $('.AddPlayer').click(function (e) {
        e.preventDefault();
        var eventid = this.attr('id');
        $.ajax({
            url: "/Tournament/SignUpToEvent",
            dataType: 'json',
            type: "POST",
            data: { EventID: eventid },
            context: document.body
        });
    });

    $('.RemovePlayer').click(function (e) {
        e.preventDefault();
        ///If it has this class it is the admin that is removing a player
        if (this.hasClass("EventA")) {
            var string = this.attr('id');
            var arr = string.split('-');
            var eventID = arr[1];
            var UserID = arr[0];
            $.ajax({
                url: "/Tournament/SignUpToEvent",
                dataType: 'json',
                type: "POST",
                data: { EventID: eventid, UserID: UserID },
                context: document.body
            });
        }
        else {
            var eventid = this.attr('id');
            $.ajax({
                url: "/Tournament/SignUpToEvent",
                dataType: 'json',
                type: "POST",
                data: { EventID: eventid },
                context: document.body
            });
        }
    });
    //////////////////////////////////////End Event Add&Remove Player//////////////////////////////////////////////////////

}); //Document ready