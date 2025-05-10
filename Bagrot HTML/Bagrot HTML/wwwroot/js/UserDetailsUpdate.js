function checkId() {
    const id = document.getElementById("userId").value;
    const errorElement = document.getElementById("errorUserId");

    errorElement.innerHTML = "";

    if (id === "") {
        errorElement.innerHTML = "This field cannot be empty.";
        return false;
    }
    if (isNaN(id)) {
        errorElement.innerHTML = "ID must be a number.";
        return false;
    }
    return true;
}

function checkFirstName() {
    const firstName = document.getElementById("firstName").value;
    const errorElement = document.getElementById("errorFirstName");

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

function checkLastName() {
    const lastName = document.getElementById("lastName").value;
    const errorElement = document.getElementById("errorLastName");

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
    const password = document.getElementById("password").value;
    const errorElement = document.getElementById("errorPassword");

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
    const confirmPassword = document.getElementById("confirmPassword").value;
    const password = document.getElementById("password").value;
    const errorElement = document.getElementById("errorConfirmPassword");

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

function checkYearOfBirth() {
    const currentYear = new Date().getFullYear();
    const yearOfBirth = document.getElementById("yearOfBirth").value;
    const errorElement = document.getElementById("errorYearOfBirth");

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
    const radioButtons = document.getElementById("Gender");
    const errorElement = document.getElementById("errorGender");

    errorElement.innerHTML = "";

    if (radioButtons.selectedIndex === 0) {
        errorElement.innerHTML = "Please select a valid option.";
        return false;
    }

    return true;
}

function checkPhoneNum() {
    const phoneNumber = document.getElementById("phone").value;
    const errorElement = document.getElementById("errorPhone");

    errorElement.innerHTML = "";

    let regExPhone = /^\d{7}$/;

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
    const email = document.getElementById("email").value;
    const errorElement = document.getElementById("errorEmail");

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
    const prefix = document.getElementById("prefix");
    const errorElement = document.getElementById("errorPrefix");

    errorElement.innerHTML = "";

    if (prefix.selectedIndex === 0) {
        errorElement.innerHTML = "Please select a valid option.";
        return false;
    }

    return true;
}

function checkCityID() {
    const CityID = document.getElementById("CityID");
    const errorElement = document.getElementById("errorCityID");

    errorElement.innerHTML = "";

    if (CityID.selectedIndex === 0) {
        errorElement.innerHTML = "Please select a valid option.";
        return false;
    }

    return true;
}

function checkUserName() {
    const userName = document.getElementById("userName").value;
    const errorElement = document.getElementById("errorUserName");

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

let isSearch = false
function isSearchTrue() {
    isSearch = true;
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

    if (isSearch) {
        return true;
    }
    return isFormOK;
}