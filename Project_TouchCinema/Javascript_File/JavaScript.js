
var emailFormat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
var phoneFormat = /^0[1-9][0-9]+$/;

function LoadLoginForm() {
    var form = document.getElementById("form1");
    form.style.opacity = "0.2";
    form.style.zIndex = "1";
    var t = document.getElementById("login_form");
    t.style.transition = "all 2s";
    t.style.top = "150px";
    t.style.opacity = "1";
    t.style.zIndex = "3";
    
}
function CloseLoginForm() {
    var t = document.getElementById("login_form");
    t.style.transition = "all 1s";
    t.style.top = "-500px";
    var form = document.getElementById("form1");
    form.style.opacity = "1";
}
function HideInvalidMessage() {
    var t = document.getElementsByClassName("error_message_show");
    for (var i = 0; i < t.length; i++) {
        t[i].className = "error_message";
    }
}

function ValidateBookingCode() {
    var t = document.getElementById("txtBookingCode").value;
    if (t.length === 10) {
        return true;
    } else {
        document.getElementById("incorrectCode").style.visibility = "visible";
        return false;
    }
}

function ModifyBesideDiv() {
    var h = document.getElementById("content").offsetHeight;
    if (h > 500) {
        document.getElementById("left_side").style.height = h + "px";
        document.getElementById("right_side").style.height = h + "px";
    }
}

function HideErrorMessage() {
    for (var i = 0; i < arguments.length; i++) {
        t = document.getElementById(arguments[i]);
        t.style.visibility = "hidden";
    }
}

function ValidateMemberRegisterInfo() {
    var t = document.getElementById("txtUsername");
    if (t.value == '') {
        document.getElementById("usernameRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (t.value.length > 20) {
            document.getElementById("usernameLength").style.visibility = "visible";
            t.focus();
            return false;
        }
    }
    t = document.getElementById("txtPass");
    var password = t.value;
    if (t.value == '') {
        document.getElementById("passRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (t.value.length > 10) {
            document.getElementById("passLength").style.visibility = "visible";
            t.focus();
            return false;
        }
    }

    t = document.getElementById("txtConfirmPass");
    if (t.value == '') {
        document.getElementById("confirmPassRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (t.value != password) {
            document.getElementById("confirmPassMatch").style.visibility = "visible";
            t.focus();
            return false;
        }
    }

    t = document.getElementById("txtFirstName");
    if (t.value == '') {
        document.getElementById("firtnameRequire").style.visibility = "visible";
        t.focus();
        return false;
    }

    t = document.getElementById("txtLastName");
    if (t.value == '') {
        document.getElementById("latnameRequire").style.visibility = "visible";
        t.focus();
        return false;
    }

    t = document.getElementById("txtPhone");
    if (t.value == '') {
        document.getElementById("phoneRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (t.value.length < 10 || t.value.length > 11) {
            document.getElementById("phoneFormat").style.visibility = "visible";
            t.focus();
            return false;
        } else
            if (!phoneFormat.test(t.value)) {
                document.getElementById("phoneFormat").style.visibility = "visible";
                t.focus();
                return false;
            }
    }

    t = document.getElementById("txtEmail");
    if (t.value.toLowerCase() == '') {
        document.getElementById("emailRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (!emailFormat.test(t.value)) {
            document.getElementById("emailFormat").style.visibility = "visible";
            t.focus();
            return false;
        }
    }

    var day = document.getElementById("dlDay");
    if (day.value == 'Day') {
        document.getElementById("dateInvalid").style.visibility = "visible";
        t.focus();
        return false;
    }

    var month = document.getElementById("dlMonth");
    if (month.value == 'Month') {
        document.getElementById("dateInvalid").style.visibility = "visible";
        t.focus();
        return false;
    }

    var year = document.getElementById("dlYear");
    if (year.value == 'Year') {
        document.getElementById("dateInvalid").style.visibility = "visible";
        t.focus();
        return false;
    }

    if (!isValidDate(day.value, month.value, year.value)) {
        document.getElementById("dateInvalid").style.visibility = "visible";
        return false;
    }

    t = document.getElementById("chkAgree");
    if (t.checked == false) {
        document.getElementById("termCheck").style.visibility = "visible";
        return false;
    }
    return true;
}

function CheckBeforeRegister() {
    var result = ValidateMemberRegisterInfo();
    if (!result) {
        document.getElementById("invalidInput").style.visibility = "visible";
    }
    return result;
}

function isValidDate(day, month, year) {

    var date = new Date();
    date.setFullYear(year, month - 1, day);
    // month - 1 since the month index is 0-based (0 = January)

    if ((date.getFullYear() == year) && (date.getMonth() == month - 1) && (date.getDate() == day))
        return true;

    return false;
}
function ChangeColor() {
    var t = document.getElementById("txtUsername");
    t.style.color = "black";
}

function CheckLoginInput() {
    for (var i = 0; i < arguments.length; i++) {
        var t = document.getElementById(arguments[i]).value;
        if (t == '') {
            document.getElementById("invalidLogin").className = "error_message_show";
            return false;
        }
    }
    return true;
}

function CheckBeforeUpdate() {
    var result = ValidateMemberUpdateInfo();
    if (!result) {
        document.getElementById("invalidInput").style.visibility = "visible";
    }
    return result;
}


function ValidateMemberUpdateInfo() {

    var t = document.getElementById("txtFirstName");
    if (t.value == '') {
        document.getElementById("firtnameRequire").style.visibility = "visible";
        t.focus();
        return false;
    }

    t = document.getElementById("txtLastName");
    if (t.value == '') {
        document.getElementById("latnameRequire").style.visibility = "visible";
        t.focus();
        return false;
    }

    t = document.getElementById("txtPhone");
    if (t.value == '') {
        document.getElementById("phoneRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (t.value.length < 10 || t.value.length > 11) {
            document.getElementById("phoneFormat").style.visibility = "visible";
            t.focus();
            return false;
        } else
            if (!phoneFormat.test(t.value)) {
                document.getElementById("phoneFormat").style.visibility = "visible";
                t.focus();
                return false;
            }
    }

    t = document.getElementById("txtEmail");
    if (t.value.toLowerCase() == '') {
        document.getElementById("emailRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (!emailFormat.test(t.value)) {
            document.getElementById("emailFormat").style.visibility = "visible";
            t.focus();
            return false;
        }
    }

    var day = document.getElementById("dlDay");
    if (day.value == 'Day') {
        document.getElementById("dateInvalid").style.visibility = "visible";
        t.focus();
        return false;
    }

    var month = document.getElementById("dlMonth");
    if (month.value == 'Month') {
        document.getElementById("dateInvalid").style.visibility = "visible";
        t.focus();
        return false;
    }

    var year = document.getElementById("dlYear");
    if (year.value == 'Year') {
        document.getElementById("dateInvalid").style.visibility = "visible";
        t.focus();
        return false;
    }

    if (!isValidDate(day.value, month.value, year.value)) {
        document.getElementById("dateInvalid").style.visibility = "visible";
        return false;
    }

    return true;
}

function ValidateChangePass() {
    var t = document.getElementById("txtOldPass");
    if (t.value == '') {
        document.getElementById("oldpassRequire").style.visibility = "visible";
        t.focus();
        return false;
    } 

    t = document.getElementById("txtNewPass");
    var password = t.value;
    if (t.value == '') {
        document.getElementById("newpassRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (t.value.length > 10) {
            document.getElementById("newpassLength").style.visibility = "visible";
            t.focus();
            return false;
        }
    }

    t = document.getElementById("txtConfirmPass");
    if (t.value == '') {
        document.getElementById("confirmPassRequire").style.visibility = "visible";
        t.focus();
        return false;
    } else {
        if (t.value != password) {
            document.getElementById("confirmPassMatch").style.visibility = "visible";
            t.focus();
            return false;
        }
    }

    return true;
}

function CheckFeedbackInformation() {
    var t = document.getElementById("txtFeedback");
    if (t.value == '') {
        return false;
    }
    t = document.getElementById("txtEmail");
    if (!emailFormat.test(t.value)) {
        document.getElementById("emailFormat").style.visibility = "visible";
        t.focus();
        return false;
    }
    t = document.getElementById("txtPhone");
    if (!phoneFormat.test(t.value)) {
        document.getElementById("phoneFormat").style.visibility = "visible";
        t.focus();
        return false;
    }
    return true;
}
