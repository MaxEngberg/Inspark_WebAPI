var groupId = null;

$(document).ready(function () {

    $(function () {
        $(document).tooltip();
    });

    $('#search').keydown(function () {
        $('.userList').html('');
        var searchField = $('#search').val();
        var expression = new RegExp(searchField, "i");

        $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/User", function (result) {
            $.each(result, function (key, value) {
                if (value.FirstName.search(expression) != -1) {
                    $('.userList').append($("<li id='userElement' data-userId='' ></li>").data('userId', value.Id).html(value.FirstName + " " + value.LastName));
                    var element = document.getElementsByClassName('userElement').data('userId');
                    console.log(element);
                }

            });

        })
    });

    $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/Section", function (result) {
        $.each(result, function (i, value) {
            $('#DropDown').append($("<option></option>").val(value.Id).html(value.Name));
        });
        var e = document.getElementById("DropDown").value;

        success: if (e != "Select Section") {
            getGroups();
        }
    });

});


$('#DropDown').change(function () {
    var e = document.getElementById("DropDown");
    var sectionId = e.options[e.selectedIndex].value;
    $('#DropDownGroups').empty();

    $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/Group/GetGroupsFromSection/" + sectionId + "", function (result) {
        $.each(result, function (i, value) {
            $('#DropDownGroups').append($("<option></option>").val(value.Id).html(value.Name));
        });
    });
});

$('#btnShowGroupMembers').click(function () {
    var e = document.getElementById("DropDownGroups");
    groupId = e.options[e.selectedIndex].value;
    $('.usersOfGroupList').empty();

    $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/Group/GetUsersFromGroup/" + groupId + "", function (result) {
        $.each(result, function (i, value) {
            $('body').data('userEmail', value.Email);
            $('.usersOfGroupList').append($("<li id='userElement' data-userId='' title='" + $("body").data('userEmail') + "'></li>").data('userIdFromGroups', value.Id).html(value.FirstName + " " + value.LastName));

        });
    });
});
function getGroups() {
    var e = document.getElementById("DropDown");
    var sectionId = e.options[e.selectedIndex].value;
    $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/Group/GetGroupsFromSection/" + sectionId + "", function (result) {
        $.each(result, function (i, value) {
            $('#DropDownGroups').append($("<option></option>").val(value.Id).html(value.Name));

        });
    });
};
$(document).ready(function () {

    $(".dragable").sortable({
        connectWith: ".usersOfGroupList",
        dropOnEmpty: true,
        remove: function (e, ui) {
            var $this = $(this);
            var childs = $this.find('li');
            if (childs.length === 0) {
                $this.text("Nothing");
            }
        },
        receive: function (e, ui) {
            var array = [];
            var matches = 0;
            var $this = $(this);
            $this.find('li').each(function (i) {
                array.push($(this).data('userIdFromGroups'));
            });
            var user = ui.item.data('userId');
            for (var i = 0; i < array.length; i++) {
                if (array[i] === user) {
                    alert("Användaren finns redan med i gruppen.");
                    matches++;
                    ui.sender.sortable("cancel");
                    break;
                }
            };
            if (matches == 0) {
                addUserToGroup(user, groupId);
                $(this).contents().filter(function () {
                    return this.nodeType == 3;
                }).remove();
            };

        },
    }).disableSelection();
});

function addUserToGroup(userId, groupId) {
    $.ajax({
        url: 'http://oruinsparkwebapi.azurewebsites.net/api/Group/AddUserToGroup/' + groupId + '/' + userId + '',
        method: 'POST',
        success: function () {
            console.log("Rätt");
        },
        error: function (xhr, status, error) {
            console.log("Fel");
        }
    });
};