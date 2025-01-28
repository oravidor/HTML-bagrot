function checkEmail(){

}


function checkFirstName() {
    
}

function checkLastName(){

}

function checkUserName(){

}

function checkPassword() {
    const password = document.getElementById("reg_password").value;
    const errorElement = document.getElementById("reg_errorPassword");

    errorElement.innerHTML = "";

    if (password.length < 5) {
        errorElement.innerHTML = "Password length must be at least 5 characters.";
        return false;
    }

    if (password.length > 15) {
        errorElement.innerHTML = "Password length must not exceed 15 characters.";
        return false;
    }

    if (!/[a-z]/.test(password)) {
        errorElement.innerHTML = "Your password needs a lowercase letter.";
        return false;
    }

    if (!/[A-Z]/.test(password)) {
        errorElement.innerHTML = "Your password needs an uppercase letter.";
        return false;
    }

    if (!/[0-9]/.test(password)) {
        errorElement.innerHTML = "Your password needs a number.";
        return false;
    }

    return true;
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