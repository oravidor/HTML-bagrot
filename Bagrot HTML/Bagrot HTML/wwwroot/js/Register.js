function checkFirstName() {
    const firstName = document.getElementById("reg_firstName").value;
    const errorElement = document.getElementById("reg_errorFirstName");

    errorElement.innerHTML = "";

    let regExFirstName = /^[A-Z][a-zA-Z\s-]{0,20}[a-zA-Z]$/;

    if (!regExFirstName.test(firstName)) {
        errorElement.innerHTML = "Invalid first name";
        return false;
    }
    return true;
}
function checkLastName(){
    const lastName = document.getElementById("reg_lastName").value;
    const errorElement = document.getElementById("reg_errorLastName");

    errorElement.innerHTML = "";

    let regExFirstName = /^[A-Z][a-zA-Z\s-]{0,20}[a-zA-Z]$/;

    if (!regExFirstName.test(lastName)) {
        errorElement.innerHTML = "Invalid last name";
        return false;
    }
    return true;
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
    const currentYear = new Date().getFullYear();
    const yearOfBirth = document.getElementById("reg_yearOfBirth").value;
    const errorElement = document.getElementById("reg_errorYearOfBirth");

    const age = currentYear - yearOfBirth;

    errorElement.innerHTML = "";

    if (age >= 16) {
        return true;
    } else {
        errorElement.innerHTML = "You are need to by older than 16 years";
        return false;
    }
   
}
function clearTextFields() {
    const textInputs = document.querySelectorAll("input[type='text'], input[type='email'], input[type='password'], input[type='number']");

    textInputs.forEach(input => input.value = "");
}