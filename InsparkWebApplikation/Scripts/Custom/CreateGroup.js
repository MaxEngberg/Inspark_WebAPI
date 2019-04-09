function CreateGroup() {
    var name = document.getElementById("tfName").value;
    var introGroup = document.querySelector('input[name="introGroup"]:checked').value;
    var sections = document.getElementById("dropDownSections");
    var section = sections.options[sections.selectedIndex].value;
    var message = { Name: name, SectionId: section, IsIntroGroup: introGroup };

    $.ajax({
        url: 'http://oruinsparkwebapi.azurewebsites.net/api/Group/AddGroup',
        method: 'POST',
        data: JSON.stringify(message),
        contentType: 'application/json',
        success: function () {
            $('#divErrorText').text("Gruppen med namn " + name + " skapades.");
            $('#divError').show('fade');
            document.getElementById("tfName").value = "";
        },
        error: function (xhr, status, error) {
            $('#divErrorText').text(xhr.responseText);
            $('#divError').show('fade');
        }
    });

};
$(document).ready(function () {
    $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/Section", function (result) {
        $.each(result, function (i, value) {
            $('#dropDownSections').append($("<option></option>").val(value.Id).html(value.Name));
        });
    });
});