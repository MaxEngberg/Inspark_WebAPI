$(document).ready(function () {
    if (sessionStorage.getItem('accessToken') == null) {
        window.location.href = "http://oruinsparkwebapplikation.azurewebsites.net/";
    }

    $('#btnLogoff').click(function () {
        sessionStorage.removeItem('accessToken');
        window.location.href = "http://oruinsparkwebapplikation.azurewebsites.net/";
    });

    $('#btnCreateUsers').click(function () {
        window.location.href = "http://oruinsparkwebapplikation.azurewebsites.net/Home/CreateUser";
    });
    $('#btnCreateGroup').click(function () {
        window.location.href = "http://oruinsparkwebapplikation.azurewebsites.net/Home/CreateGroup";
    });
    $('#btnAddUsersToGroups').click(function () {
        window.location.href = "http://oruinsparkwebapplikation.azurewebsites.net/Home/AddUserToGroup";
    });
    $('#btnGenerateCode').click(function () {
        window.location.href = "http://oruinsparkwebapplikation.azurewebsites.net/Home/CodeGenerator";
    });
    $('#linkClose').click(function () {
        $('#divError').hide('fade');
    });

    $('#errorModal').on('hidden.bs.modal', function () {
        window.location.href = "Login.html";
    });

});