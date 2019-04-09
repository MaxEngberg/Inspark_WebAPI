function CreateUser() {
    var email = document.getElementById("tfEmail").value;
    var password = document.getElementById("tfPassword").value;
    var confirmPassword = document.getElementById("tfConfirmPassword").value;
    var firstName = document.getElementById("tffirstName").value;
    var lastName = document.getElementById("tflastName").value;
    var sections = document.getElementById("dropDownSections");
    var section = sections.options[sections.selectedIndex].value;
    var role = document.querySelector('input[name="Roles"]:checked').value;

    var message = { Email: email, Password: password, ConfirmPassword: confirmPassword, Role: role, Firstname: firstName, Lastname: lastName, Section: section };

    $.ajax({
        url: 'http://oruinsparkwebapi.azurewebsites.net/api/Account/Register',
        method: 'POST',
        data: JSON.stringify(message),
        contentType: 'application/json',
        success: function () {
            $('#divErrorText').text("Användaren " + email + " skapad.");
            $('#divError').show('fade');
        },
        error: function (xhr, status, error) {
            $('#divErrorText').text(xhr.responseText);
            $('#divError').show('fade');
        }
    });
};

$('#btnCleanWindow').click(function () {
    document.getElementById("tfEmail").value = "";
    document.getElementById("tfPassword").value = "";
    document.getElementById("tfConfirmPassword").value = "";
    document.getElementById("tffirstName").value = "";
    document.getElementById("tflastName").value = "";
});