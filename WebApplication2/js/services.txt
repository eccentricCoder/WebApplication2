var studentAdditionActive = false;
var addLink = document.getElementById('lnkAdd');
var btnAdd = document.getElementById('btnAdd');
var fName = document.getElementById('fName');
var lName = document.getElementById('lName');

var email = document.getElementById('email');
var enrollDate = document.getElementById('enrollDate');

function AddStudent() {
    if (studentAdditionActive == false) {
        addLink.innerText = 'Cancel';
        btnAdd.removeAttribute("class");
        btnAdd.removeAttribute("disabled");
        fName.removeAttribute("class");
        lName.removeAttribute("class");
        email.removeAttribute("class");
        enrollDate.removeAttribute("class");
        studentAdditionActive = true;
    }
    else {
        addLink.innerText = 'Add';
        btnAdd.setAttribute("class", "inactive");
        btnAdd.setAttribute("disabled", "disabled");
        fName.setAttribute("class", "inactive");
        fName.value = '';
        lName.setAttribute("class", "inactive");
        lName.value = '';
        email.setAttribute("class", "inactive");
        email.value = '';
        enrollDate.setAttribute("class", "inactive");
        enrollDate.value = '';
        studentAdditionActive = false;
    }
}

addLink.addEventListener("click", AddStudent, false);