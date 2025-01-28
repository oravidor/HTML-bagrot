function checkEmail(){

}


function checkFirstName(){

}

function checkLastName(){

}

function checkUserName(){

}

function checkPassword(){

}

function checkConfirmPassword() {
    const confirmPassword = document.getElementById("reg_confirmPassword").value;
    const password = document.getElementById("reg_password").value;
    const errorElement = document.getElementById("reg_errorConfirmPassword");

    errorElement.innerHTML = "";

    if (confirmPassword === password) {
        return true;
    } else {
        errorElement.innerHTML = "Passwords do not match";
        return false;
    }
}

function checkYearOfBirth(){

}

function reset(){

}