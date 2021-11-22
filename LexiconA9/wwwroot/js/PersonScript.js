function GetPeopleList() {
    $.get("/Ajax/GetPersons", null, function (data) {
        $("#ContentDiv").html(data);
    });
}

function GetPersonByID() {
    var personID = document.getElementById('PersonID').value;
    $.post("/Ajax/GetPersonById", { personID: personID }, function (data) {
        $("#ContentDiv").html(data);
    });
}

function DeletePersonById() {
    var personID = document.getElementById('PersonID').value;
    $.post("/Ajax/DeletePersonById", { personID: personID }, function (data) {})
        .done(function () {
            document.getElementById('errorMessages').innerHTML = "Person ID " + personID + " has been deleted.";
            GetPeopleList();
        })
        .fail(function () {
            document.getElementById('errorMessages').innerHTML = "Could not delete person with ID " +personID +".";
        });
}
//merge these
function DeletePersonByIdRow(id) {
    $.post("/Ajax/DeletePersonById", { personID: id }, function (data) { })
        .done(function () {
            document.getElementById('errorMessages').innerHTML = "Person ID " + id + " has been deleted.";
            GetPeopleList();
        })
        .fail(function () {
            document.getElementById('errorMessages').innerHTML = "Could not delete person with ID " + id + ".";
        });
}