function checkFirstName() {
    const firstName = document.getElementById("reg_firstName").value;
    const errorElement = document.getElementById("reg_errorFirstName");

    errorElement.innerHTML = "";

    let regExFirstName = /^[A-Z][a-zA-Z\s-]{0,20}[a-zA-Z]$/;

    if (firstName === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

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

    if (lastName === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

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

    if (password === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

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

    if (confirmPassword === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

    if (confirmPassword === password) {
        return true;
    } else {
        errorElement.innerHTML = "Passwords do not match";
        return false;
    }
    return true;
}

function checkYearOfBirth(){
    const currentYear = new Date().getFullYear();
    const yearOfBirth = document.getElementById("reg_yearOfBirth").value;
    const errorElement = document.getElementById("reg_errorYearOfBirth");

    errorElement.innerHTML = "";

    if (yearOfBirth === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

    const age = currentYear - yearOfBirth;

    if (age >= 16) {
        return true;
    } else {
        errorElement.innerHTML = "You are need to by older than 16 years";
        return false;
    }
    return true;
}

function checkRadioButtons() {
    const radioButtons = document.getElementsByName('user.Gender'); 
    const errorElement = document.getElementById("reg_errorGender");
    let isSelected = false;

    errorElement.innerHTML = "";

    for (const radioButton of radioButtons) {
        if (radioButton.checked) {
            isSelected = true;
            break;
        }
    }

    if (!isSelected) {
        errorElement.innerHTML = "You need to select a gender"; 
        return false;
    }

    return true;
}

function checkPhoneNum() {
    const phoneNumber = document.getElementById("reg_phone").value;
    const errorElement = document.getElementById("reg_errorPhone");

    errorElement.innerHTML = "";

    let regExPhone = /^\d{10}$/;

    if (phoneNumber === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

    if (!regExPhone.test(phoneNumber)) {
        errorElement.innerHTML = "Invalid phone number";
        return false;
    }
    return true;
}

function checkEmail() {
    const email = document.getElementById("reg_email").value;
    const errorElement = document.getElementById("reg_errorEmail");

    errorElement.innerHTML = "";

    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (email === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

    if (!emailPattern.test(email)) {
        errorElement.innerHTML = "Invalid email address.";
        return false;
    }
    return true;
}

function checkPrefix() {
    const prefix = document.getElementById("reg_prefix");
    const errorElement = document.getElementById("reg_errorPrefix");

    errorElement.innerHTML = "";

    if (prefix.selectedIndex === 0) {
        errorElement.innerHTML = "Please select a valid option.";
        return false;
    }

    return true;
}

function checkCityID() {
    const CityID = document.getElementById("reg_CityID");
    const errorElement = document.getElementById("reg_errorCityID");

    errorElement.innerHTML = "";

    if (CityID.selectedIndex === 0) {
        errorElement.innerHTML = "Please select a valid option.";
        return false;
    }

    return true;
}

function checkUserName() {
    const userName = document.getElementById("reg_userName").value;
    const errorElement = document.getElementById("reg_errorUserName");

    errorElement.innerHTML = "";

    if (userName === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }

    return true;
}

function clearTextFields() {
    const textInputs = document.querySelectorAll("input[type='text'], input[type='email'], input[type='password'], input[type='number']");
    textInputs.forEach(input => input.value = "");

    const radioButtons = document.querySelectorAll("input[type='radio']");
    radioButtons.forEach(radio => radio.checked = false);

    const dropdowns = document.querySelectorAll("select");
    dropdowns.forEach(select => select.selectedIndex = 0);

    const errorMessages = document.querySelectorAll("span.text-danger");
    errorMessages.forEach(span => span.innerHTML = "");
}



function validateRegisterForm() {
    let isFormOK = true;

    isFormOK = checkConfirmPassword() && isFormOK;
    isFormOK = checkFirstName() && isFormOK;
    isFormOK = checkLastName() && isFormOK;
    isFormOK = checkPassword() && isFormOK;
    isFormOK = checkYearOfBirth() && isFormOK;
    isFormOK = checkRadioButtons() && isFormOK;
    isFormOK = checkPhoneNum() && isFormOK;
    isFormOK = checkEmail() && isFormOK;
    isFormOK = checkPrefix() && isFormOK;
    isFormOK = checkCityID() && isFormOK;
    isFormOK = checkUserName() && isFormOK;

    return isFormOK;
}