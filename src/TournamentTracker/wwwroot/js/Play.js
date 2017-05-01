//////////////Variables////////////////////////

//////////////End Variables ///////////////////
$(document).ready(function () {
    var signalHub = $.connection.playHub;
    //Signal
    $.connection.hub.logging = true;
  
    $.connection.hub.start().done(function () {
        console.log("hey");
        signalHub.server.connectPlayer("90f59793-c159-4013-8125-7a1bc3da63d2", 1);
    });


    //Log in the user
    //$.connection.hub.start().done(function (SignalRConnection) {
    //    console.log("hey");
    //    $.connection.playHub.server.connect();
    //});

    
    signalHub.client.update = function (PlayersList) {
        alert("hi");
        $('#PlayersList').html();
        $.each(PlayersList, function (index, value) {
            $('#PlayersList').append(value);
        });
    };
    //End SignalR
});