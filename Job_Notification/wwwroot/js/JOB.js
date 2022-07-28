$(document).ready(function () {
        //auto display dats
});

function loadData() {
    debugger;
    $.ajax({
        url: 'Employee/GetEmployee',
        type: "GET",

        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.age + '</td>';
                html += '<td>' + item.address + '</td>';
                html += '<td>' + item.salary + '</td>';
                html += '<td>' + item.gender + '</td>';
                html += '<td><a href="#" onclick="return Edit(' + item.id + ')" class="btn btn-sm btn-primary">Edit</a> | <a href="#" onclick="Delete(' + item.id + ')" class="btn btn-sm btn-danger">Delete</a></td>';
                html += '</tr>';
            });
            $(function () {
                $('.tbody').html(html)
                $('#PeopleTable').DataTable({
                    dom: 'Bfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print', 'excelhtml5',
                        /*{ extent: "print", text: "<span class='glyphicon glyphicon-print'></span> Print" },*/
                        { extent: "excelhtml5", text: "<span class='glyphicon glyphicon-th-list'></span> excel html5 export" },
                        { extent: "pdfhtml5", text: "<span class='glyphicon glyphicon-save'></span> pdf html5 export", title: "filename" }
                    ]
                });
            });
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });
}


function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var obj = {
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Email: $('#email').val(),
        Password: $('#password').val(),
        ConfirmPassword: $('#confirmpassword').val(),
        Gender: $('#Gender').val(),
        PhoneNumber: $('#PhoneNumber').val(),
        address: $('#address').val(),
    };
    $.ajax({
        type: "POST",
        url: '/User/CreateUser',
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(obj),
        success: function () {
            $('#myModal').modal('hide');
            $('#FirstName').val("");
            $('#LastName').val("");
            $('#email').val("");
            $('#password').val("");
            $('#Gender').val("");
            $('#PhoneNumber').val("");
            $('#address').val("");
            swal("Good job!", "Record Save Successfully!", "success");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Edit(Id) {
    debugger;
    $("#myModalLabel").text("Edit Details");
    $("#Id").parent().show();
    $('#Name').css('border-color', 'lightgrey');
    $.ajax({
        url: 'Employee/Show?id=' + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result.length > 0) {
                /* debugger;*/
                $('#Id').val(result[0].id);
                $('#Name').val(result[0].name);
                $('#Age').val(result[0].age);
                $('#Address').val(result[0].address);
                $('#Salary').val(result[0].salary);
                $('#Gender').val(result[0].gender);
                $('#myModal').modal('show');
                $('#btnUpdate').show();
                $('#btnAdd').hide();
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Update() {

    var res = validate();
    if (res == false) {
        return false;
    }
    var obj = {
        Id: parseInt($('#Id').val()),
        Name: $('#Name').val(),
        Age: parseInt($('#Age').val()),
        Address: $('#Address').val(),
        Salary: parseInt($('#Salary').val()),
        Gender: $('#Gender').val(),
    };
    $.ajax({
        url: 'Employee/UpdateEmployee',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        success: function () {
            loadData();
            $('#myModal').modal('hide');
            $('#Id').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#Address').val("");
            $('#Salary').val("");
            $('#Gender').val("");
            swal('Record Updated!');
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delete(Id) {
    if (confirm("Are you sure, You want to delete this Record?")) {
        /*  debugger;*/
        $.ajax({
            url: 'Employee/DeleteEmployee?id=' + Id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            success: function () {

                alert('Record is Successfully Removed in Database!');
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function HideKey() {
    $("#myModalLabel").text("Add New User");
    $("#Id").parent().hide();
}


//Function for clearing the textboxes  
function clearTextBox() {
    $('#Id').val("");
    $('#Name').val("");
    $('#Age').val("");
    $('#Address').val("");
    $('#Salary').val("");
    $('#Gender').val();
    $('#btnAdd').show();
    $('#btnUpdate').hide();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Salary').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#FirstName').val().trim() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }
    if ($('#LastName').val().trim() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }
    if ($('#email').val().trim() == "") {
        $('#email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#email').css('border-color', 'lightgrey');
    }
    if ($('#password').val().trim() == "") {
        $('#password').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#password').css('border-color', 'lightgrey');
    }
    if ($('#confirmpassword').val().trim() == "") {
        $('#confirmpassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#confirmpassword').css('border-color', 'lightgrey');
    }
    if ($('#PhoneNumber').val().trim() == "") {
        $('#PhoneNumber').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PhoneNumber').css('border-color', 'lightgrey');
    }
    if ($('#address').val().trim() == "") {
        $('#address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#address').css('border-color', 'lightgrey');
    }
    if ($('#Gender').val().trim() == "") {
        $('#Gender').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Gender').css('border-color', 'lightgrey');
    }
    return isValid;
}