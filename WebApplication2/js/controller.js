﻿var StudentInfoApp = angular.module('StudentInfoApp', []);

// Snapshot A - Working with static data
//StudentInfoApp.controller('StudentController', function ($scope) {
//    $scope.StudentList = [
//        { 'StudentId' : '1', 'FirstName' : 'Alvin', 'LastName' : 'Cameron' },
//        { 'StudentId' : '2', 'FirstName' : 'Tom', 'LastName' : 'Martin' }
//    ];
//});

// Grabing data from the server
var host = location.protocol + "//" + window.location.host + "/api/Student";
var putUrl = location.protocol + "//" + window.location.host + "/put";
var url = location.protocol + "//" + window.location.host + "/api/Student/";


StudentInfoApp.controller('StudentController', function ($scope, $http) {
    $scope.student = [];
  

    function loadData() {
        $http.get(host).success(function (data) {
            $scope.StudentList = data;
        });
    };

    $scope.deleteStudent = function(val) {
        var student = $scope.StudentList[val];
        var index = student.StudentId;
        $http.delete(url+index).success(function (data) { loadData(); });
    };

    var email = document.getElementById('email');
    var enrollDate = document.getElementById('enrollDate');
    $scope.addStudent = function () {
        var student = {
            'studentId': '0',
            'firstName': document.getElementById('fName').value,
            'lastName': document.getElementById('lName').value,
            'email': document.getElementById('email').value,
            'studentNumber': ' ',
            'enrollDate': document.getElementById('enrollDate').value
        };

        $http.post(url, student).success(function (data) {
            loadData();
            studentAdditionActive = false;
            var addLink = document.getElementById('lnkAdd');
            var btnAdd = document.getElementById('btnAdd');
            var fName = document.getElementById('fName');
            var lName = document.getElementById('lName');
            var email = document.getElementById('email');
            var enrollDate = document.getElementById('enrollDate');

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
            addLink.innerText = 'Add';
        })

    };

    loadData();
});