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

var ConfirmDelete = function (id, username) {
    $('#hiddenUserId').val(id)
    $('#details-modal-title').html("Delete Employee");
    $('#modal-admin-body').html("Are you sure you want to permanently delete " + username + "?");
    $('#set-admin-modal').modal('show');   
}

var DeleteEmployee = function () {
    var Id = $('#hiddenUserId').val()

    $.ajax({
        type: "POST",
        url: "/Administration/Delete",
        data: { Id: Id },
        success: function (response) {
            $('#details-modal').modal('hide');
        }

    })
}

   