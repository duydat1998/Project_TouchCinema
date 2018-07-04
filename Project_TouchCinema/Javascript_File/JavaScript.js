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
    for (i = 0; i < t.length; i++) {
        t[i].style.visibility = "hidden";
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

function ValidateMemberRegisterInfo() {

}