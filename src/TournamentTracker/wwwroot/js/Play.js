//////////////Variables////////////////////////
    //Keeps the connection
    var signalHub = $.connection.playHub;
//////////////End Variables ///////////////////
$(document).ready(function () {
    //Signal
    $.connection.hub.logging = true;
  
    // This adds the players to the players 
    $.connection.playHub.client.test = function (players) {
        var PlayersList = JSON.parse(players);
        $.each($.parseJSON(players), function () {
            //appends the results
            $('#PlayersList').append(
                '<a href="#" class="list-group-item">' + this.username + ' <span class="pull-right text-muted small">' + this.active + '</span></a>'
                );
        });
    };
    //Starts the connection and logs the user
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