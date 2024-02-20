function getEmployees() {
    sendRequest("GET", "employee", null, getEmployeeSuccessHandler, errorHandler);
}

function getEmployeeSuccessHandler(respData) {   // insereaza in html instructiunile respective
    var dropdown = document.getElementById("selectEmployee");
    for (var i=0;i<respData.length;i++){    // respData - ce vine din request, lista de employees
        var option = document.createElement('option');
        option.value = respData[i].id;
        option.innerHTML = respData[i].id + " " + respData[i].name;
        dropdown.appendChild(option);
    }
}

function errorHandler(status) {
    alert("err response: " + status); // popup on err.
}

function getHoursWorked() {
    var employeeId = $('#selectEmployee').find(":selected").val();
    var from = $('#startDate').val();
    var to = $('#endDate').val();

    var parameters = {
        "from": from,
        "to": to
    }
    sendRequest("GET", "time_tracking/employeeDateBetween/" + employeeId, parameters, getHoursWorkedSuccessHandler, errorHandler);

}
function getHoursWorkedSuccessHandler(respData) {
    $('#result').text(respData)
}

// pentru numarul total de ore lucrate de toti angajatii
function getAllHoursWorked() {
    sendRequest("GET", "time_tracking/employeeHours", null , getAllHoursWorkedSuccessHandler, errorHandler);
}
function getAllHoursWorkedSuccessHandler(respData) {
    $('#result2').text(respData)
}


// pentru afisare id, nume si ore la fiecare angajat
function getAllId() {
    sendRequest("GET", "employee/employeeId", null , getAllIdSuccessHandler, errorHandler);
}
function getAllIdSuccessHandler(respData) {
    $('#result3').text(respData)
}
function getAllName() {
    sendRequest("GET", "employee/employeeName", null , getAllNameSuccessHandler, errorHandler);
}
function getAllNameSuccessHandler(respData) {
    $('#result4').text(respData)
}
function getAllHour() {
    sendRequest("GET", "employee/employeeHour", null , getAllHourSuccessHandler, errorHandler);
}
function getAllHourSuccessHandler(respData) {
    $('#result5').text(respData)
}


