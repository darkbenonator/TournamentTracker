$(document).ready(function () {
    //Open Modal for create location
    $('#showLocationCreation').click(function (e) {
        e.preventDefault();
        var url = $('#locationModal').data('url');

        $.get(url, function (data) {
            $('#locationContainer').html(data);

            $('#locationModal').modal('show');
        });
    });











}); //Document ready