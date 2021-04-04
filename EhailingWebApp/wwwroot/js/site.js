// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

 
var Details = function (Id, userDetails) {
    $.ajax({
        type: "POST",
        url: "/Administration/Details",
        data: { Id: Id },
        success: function (response) {
            $('#modal-details-body').html(response);
            $('#modal-details-title').html(userDetails);
            $('#details-modal').modal('show');
        }

    })
}

var Administrator = function (Id, userName) {

    $.ajax({
        type: "POST",
        url: "/Administration/Details",
        data: { Id: Id },
        success: function (response) {
            $('#modal-admin-body').html("Are you sure you want to set " + userName + " as administrator?");
            $('#details-modal-title').html("Make " + userName + " Admin?");
            $('#set-admin-modal').modal('show');
        }

    })
}