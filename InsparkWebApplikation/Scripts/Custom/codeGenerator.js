$(document).ready(function () {
    $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/Section", function (result) {
        $.each(result, function (i, value) {
            $('#DropDown').append($("<option></option>").val(value.Id).html(value.Name));
        });
    });


    $('#btnGetGroups').click(function () {
        var e = document.getElementById("DropDown");
        var sectionId = e.options[e.selectedIndex].value;

        $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/Group/GetGroupsFromSection/" + sectionId + "", function (result) {
            $.each(result, function (i, value) {
                $('#DropDownGroups').empty();
                $('#DropDownGroups').append($("<option></option>").val(value.Id).html(value.Name));
            });
        });
    });

    var counter = 1;
    var groupCount = 0;

    window.getData = function () {
        var e = document.getElementById("DropDownGroups");
        var groupId = e.options[e.selectedIndex].value;
        var codes = document.getElementById("tfHowManyCodes").value;

        $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/ActivationCode/ReturnCountForGroup/" + groupId + "", function (result) {
            groupCount = result;
            if (groupCount < 70 && codes < 70) {

                var message = { GroupId: groupId }

                if (counter <= codes && codes < 100) {
                    $.ajax({
                        url: 'http://oruinsparkwebapi.azurewebsites.net/api/ActivationCode',
                        async: true,
                        method: 'POST',
                        data: JSON.stringify(message),
                        contentType: 'application/json',
                        dataType: "json",
                        success: function () {
                            counter++;
                            getData();
                            $('#testLabel').text("" + codes + " Koder genererade! :)").css("color", "green");
                        }
                    });
                }
            }

            else {
                $('#testLabel').text("Du kan som mest generera 70 koder för en grupp.").css("color", "red");
            }

        });
    };

    var tableValues = null;

    $('#btnCreateTableFromJSON').click(function () {
        var e = document.getElementById("DropDownGroups");
        var groupId = e.options[e.selectedIndex].value;
        $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/ActivationCode/GetCodesFromGroup/" + groupId + "", function (result) {
            tableValues = result;
        });

        var col = [];

        setTimeout(function () {
            for (var i = 0; i < tableValues.length; i++) {
                for (var key in tableValues[i]) {
                    if (col.indexOf(key) === -1) {
                        col.push(key);
                    }
                }
            }
        }, 500);

        var table = document.createElement("table");
        var tr = table.insertRow(-1);
        var codeTh = document.createElement("th");
        var activatedTh = document.createElement("th");
        codeTh.innerHTML = "Kod";
        activatedTh.innerHTML = "Activated";
        tr.appendChild(codeTh);
        tr.appendChild(activatedTh);

        for (var i = 0; i < col.length; i++) {
            var th = document.createElement("th");
            th.innerHTML = col[i];
            tr.appendChild(th);
        }
        setTimeout(function () {
            for (var i = 0; i < tableValues.length; i++) {

                tr = table.insertRow(-1);

                for (var j = 0; j < col.length; j++) {
                    if (j == 1 || j == 2) {
                        var tabCell = tr.insertCell(-1);
                        tabCell.innerHTML = tableValues[i][col[j]];
                    }
                }
            }
        }, 500);

        var divContainer = document.getElementById("showData");
        divContainer.innerHTML = "";
        divContainer.appendChild(table);

        var btn = document.createElement("BUTTON");
        var textNode = document.createTextNode("Koder till .PDF");
        btn.id = "btnCreatePDF";
        btn.appendChild(textNode);
        divContainer.appendChild(btn);

        $('#btnCreatePDF').click(function () {
            createPDF();
        });

    });
});

function createPDF() {

    var pdf = new jsPDF();
    var e = document.getElementById("DropDownGroups");
    var groupId = e.options[e.selectedIndex].value;
    $.getJSON("http://oruinsparkwebapi.azurewebsites.net/api/ActivationCode/GetCodesFromGroup/" + groupId + "", function (result) {
        $.each(result, function (i, value) {
            var imgData = 'data:image/png;base64,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'
            pdf.setFontSize(30);
            pdf.addImage(imgData, 'PNG', 50, 10, 120, 100)

            code = value.Code;
            pdf.text(90, 115, code);
            pdf.text(15, 130, "Registrera din kod i mobilapplikationen");
            pdf.addPage();

        });

        pdf.save('Test.pdf');
    });

}