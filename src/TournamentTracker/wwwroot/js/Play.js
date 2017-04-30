//////////////Variables////////////////////////
var SignalRConnection;
//////////////End Variables ///////////////////
$(document).ready(function () {
    //SignalR
    $.connection.hub.logging = true;

    //Log in the user
    $.connection.hub.start().done(function () {
        SignalRConnection.server.connectUser($('#SelectUserID').attr('id'), $('#SelectEventID').attr('id'));
    });

    SignalRConnection = $.connection.PlayHub;
    SignalRConnection.client.updateUsers = function (PlayersList) {
        $('#PlayersList').html();
        $.each(PlayersList, function (index, value) {
            $('#PlayersList').append(value);
        });
    };
    //End SignalR
});