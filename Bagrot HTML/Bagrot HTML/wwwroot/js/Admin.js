function clearTextFields() {
    const textInputs = document.querySelectorAll("input[type='text'], input[type='email'], input[type='password'], input[type='number']");
    textInputs.forEach(input => input.value = "");

    const radioButtons = document.querySelectorAll("input[type='radio']");
    radioButtons.forEach(radio => radio.checked = false);

    const dropdowns = document.querySelectorAll("select");
    dropdowns.forEach(select => select.selectedIndex = 0);
}
