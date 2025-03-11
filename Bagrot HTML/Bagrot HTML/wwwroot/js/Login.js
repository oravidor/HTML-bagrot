function checkPassword() {
    const password = document.getElementsByName("log_password").value;
    const errorElement = document.getElementById("log_errorPassword");

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

function checkEmail() {
    const email = document.getElementsByName("log_email").value;
    const errorElement = document.getElementById("log_errorEmail");

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

function validateLoginForm() {
    let isFormOK = true;

    isFormOK = checkPassword() && isFormOK;
    isFormOK = checkEmail() && isFormOK;

    return isFormOK;
}