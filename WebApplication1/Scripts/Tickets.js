var adultpersons;
var studentPersons;
var children;

var minusAdults;
var addAdults;
var minusStudents;
var addStudents;
var minusChildren;
var addChildren;

$(document).ready(function () {

    adultpersons = $('#adults');
    studentPersons = $('#students');
    children = $('#children');

    minusAdults = $('#minusAdults');
    addAdults = $('#addAdults');
    minusStudents = $('#minusStudents');
    addStudents = $('#addStudents');
    minusChildren = $('#minusChildren');
    addChildren = $('#addChildren');


    minusAdults.on('click', function () {
        minusAdultsFn();
    });

    addAdults.on('click', function () {
        addAdultsFn();
    });

    minusStudents.on('click', function () {
        minusStudentsFn();
    });

    addStudents.on('click', function () {
        addStudentsFn();
    });

    minusChildren.on('click', function () {
        minusChildrenFn();
    });

    addChildren.on('click', function () {
        addChildrenFn();
    });


    function minusAdultsFn() {
        var value = adultpersons.val();
        if (value <= 0) {
            adultpersons.val(0);
        }
        else {
            value = parseInt(value) - 1;
            adultpersons.val(value);
        }
    }

    function addAdultsFn() {
        var value = adultpersons.val();
        value = parseInt(value) + 1;
        adultpersons.val(value);
    }

    function minusChildrenFn() {
        var value = children.val();
        if (value <= 0) {
            children.val(0);
        }
        else {
            value = parseInt(value) - 1;
            children.val(value);
        }
    }

    function addChildrenFn() {
        var value = children.val();
        value = parseInt(value) + 1;
        children.val(value);
    }

    function minusStudentsFn() {
        var value = studentPersons.val();
        if (value <= 0) {
            studentPersons.val(0);
        }
        else {
            value = parseInt(value) - 1;
            studentPersons.val(value);
        }
    }
    function addStudentsFn() {
        var value = studentPersons.val();
        value = parseInt(value) + 1;
        studentPersons.val(value);
    }



});