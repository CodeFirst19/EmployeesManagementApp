// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//View employee details
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

//Confirm deleting employee
var ConfirmDelete = function (id, username) {
    $('#hiddenUserId').val(id)
    $('#delete-user-modal-title').html("Delete Employee");
    $('#delete-user-modal-body').html("Are you sure you want to permanently delete " + username + "?");
    $('#delete-employee-modal').modal('show');   
}


//Delete employee if confirmed
var DeleteEmployee = function () {
    var Id = $('#hiddenUserId').val()

    $.ajax({
        type: "POST",
        url: "/Administration/Delete",
        data: { Id: Id },
        success: function (respose) {
            $('#delete-employee-modal').modal('hide');
            var result = respose;
            window.location.href = "/Administration/Index?Response=" + result;
        }

    })
}

//Confirm assigning admin role to employee
var ConfirmAssignRole = function (id, username) {
    $('#hiddenUserId').val(id)
    $('#assign-role-modal-title').html("Make Employee Admin");
    $('#assign-role-modal-body').html("Do you want to assign admin rights to " + username + "?");
    $('#assign-role-modal').modal('show');
}

//Assign admin role to employee if confirmed
var AssignRole = function () {
    var Id = $('#hiddenUserId').val()

    $.ajax({
        type: "POST",
        url: "/Roles/AssignRole",
        data: { Id: Id },
        success: function (respose) {
            $('#assign-role-modal').modal('hide');
            var result = respose;
            window.location.href = "/Roles/Index?Response=" + result;
           
        }

    })
    //$('#assign-role-modal').modal('hide');
}
//Confirm removing admin role to employee
var ConfirmRemoveRole = function (id, username) {
    $('#hiddenUserId').val(id)
    $('#remove-role-modal-title').html("Remove Admin Rights From Employee");
    $('#remove-role-modal-body').html("Are you sure want to remove admin rights from " + username + "?");
    $('#remove-role-modal').modal('show');
}

//Remove admin role from employee if confirmed
var RemoveRole = function () {
    var Id = $('#hiddenUserId').val()

    $.ajax({
        type: "POST",
        url: "/Roles/RemoveRole",
        data: { Id: Id },
        success: function (respose) {
            $('#remove-role-modal').modal('hide');
            var result = respose;
            window.location.href = "/Roles/Index?Response=" + result;
            
        }

    })
}

   