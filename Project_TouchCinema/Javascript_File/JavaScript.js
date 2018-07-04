function LoadLoginForm() {
    var t = document.getElementById("login_form");
    t.style.transition = "all 2s";
    t.style.top = "150px";
    var form = document.getElementById("form1");
    form.style.opacity = "0.2";
    t.style.opacity = "1";
}
function CloseLoginForm() {
    var t = document.getElementById("login_form");
    t.style.transition = "all 1s";
    t.style.top = "-500px";
    var form = document.getElementById("form1");
    form.style.opacity = "1";
}
function HideInvalidMessage() {
    var t = document.getElementsByClassName("error_message");
    for ( var i = 0; i < t.length; i++) {
        t[i].style.visibility = "hidden";
    }
}

function ValidateBookingCode() {
    var t = document.getElementById("txtBookingCode").value;
    alert(t);
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
        var t = document.getElementById(arguments[i]);
        t.style.visibility = "hidden";
    }
    
}

function ValidateMemberRegisterInfo() {
    var t = document.getElementById("txtUsername").value;
    if (t == '') {
        document.getElementById("usernameRequire").style.visibility = "visible";
        return false;
    } else {
        if (t.length > 20) {
            document.getElementById("usernameLength").style.visibility = "visible";
            return false;
        }
    }
    t = document.getElementById("txtPass").value;
    var password = t;

    if (t == '') {
        document.getElementById("passRequire").style.visibility = "visible";
        return false;
    } else {
        if (t.length > 10) {
            document.getElementById("passLength").style.visibility = "visible";
            return false;
        }
    }

    t = document.getElementById("txtConfirmPass").value;
    if (t == '') {
        document.getElementById("confirmPassRequire").style.visibility = "visible";
        return false;
    } else {
        if (t != password) {
            document.getElementById("confirmPassMatch").style.visibility = "visible";
            return false;
        }
    }

    t = document.getElementById("txtFirstName").value;
    if (t == '') {
        document.getElementById("firtnameRequire").style.visibility = "visible";
        return false;
    }

    t = document.getElementById("txtLastName").value;
    if (t == '') {
        document.getElementById("latnameRequire").style.visibility = "visible";
        return false;
    }

    t = document.getElementById("txtPhone").value;
    var phoneFormat = /^0[1-9][0-9]+$/;
    if (t == '') {
        document.getElementById("phoneRequire").style.visibility = "visible";
        return false;
    } else {
        if (t.length < 10 || t.length > 11) {
            document.getElementById("phoneFormat").style.visibility = "visible";
            return false;
        } else 
        if (!phoneFormat.test(t)) {
            document.getElementById("phoneFormat").style.visibility = "visible";
            return false;
        }
    }

    t = document.getElementById("txtEmail").value.toLowerCase();
    var emailFormat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    if (t == '') {
        document.getElementById("emailRequire").style.visibility = "visible";
        return false;
    } else {
        if (!emailFormat.test(t)) {
            document.getElementById("emailFormat").style.visibility = "visible";
            return false;
        }
    }


    //dlDay
    //dlMonth
    //dlYear
    //chkAgree
    return true;
}