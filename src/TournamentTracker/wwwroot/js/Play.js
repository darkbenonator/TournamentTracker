//////////////Variables////////////////////////

//////////////End Variables ///////////////////
$(document).ready(function () {
    var signalHub = $.connection.playHub;
    //Signal
    $.connection.hub.logging = true;
  
    $.connection.playHub.client.update = function (PlayersList) {
        alert("hi");

    };

    $.connection.playHub.client.test = function (players) {
        alert(JSON.stringify(players));
        var PlayersList = JSON.parse(players);
        var i = 0;
        $.each($.parseJSON(players), function () {
            i++;
            $('#PlayersList').append(
                '<a href="#" class="list-group-item">' + this.username + ' <span class="pull-right text-muted small">' + this.active + '</span></a>'
                );
        });
        alert(i);
    };

    $.connection.hub.start().done(function () {
        var UserId = $('.SelectUserID').attr('id');
        var eventID = $('.SelectEventID').attr('id');
        signalHub.server.connectPlayer(UserId, eventID);
    });


    //Log in the user
    //$.connection.hub.start().done(function (SignalRConnection) {
    //    console.log("hey");
    //    $.connection.playHub.server.connect();
    //});

    

    //End SignalR
});