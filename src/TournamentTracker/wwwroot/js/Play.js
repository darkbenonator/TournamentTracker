//////////////Variables////////////////////////

//////////////End Variables ///////////////////
$(document).ready(function () {
    var signalHub = $.connection.playHub;
    //Signal
    $.connection.hub.logging = true;
  
    $.connection.playHub.client.update = function (PlayersList) {
        alert("hi");

    };

    $.connection.playHub.client.test= function(players){
        var PlayersList = JSON.parse(players);
        $.each(PlayersList, function (index, value) {
            $('#PlayersList').append(
                '<a href="#" class="list-group-item">' + value[0].username + ' <span class="pull-right text-muted small">' + value[0].active + '</span></a>'
               
                );
        });
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