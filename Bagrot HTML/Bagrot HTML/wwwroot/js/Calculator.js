window.onload = function () {

    document.getElementById("num1").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num2").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num3").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num4").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num5").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num6").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num7").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num8").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num9").value = Math.floor(Math.random() * 10) + 1;
    document.getElementById("num10").value = Math.floor(Math.random() * 10) + 1;
}

function checkAnswer1() {

    let num1 = parseInt(document.getElementById("num1").value);
    let num2 = parseInt(document.getElementById("num2").value);
    let result = parseInt(document.getElementById("result1").value);
    let messageElement = document.getElementById("message1");

    if (result == num1 + num2) {
        messageElement.innerHTML = "Correct";
    }
    else {
        messageElement.innerHTML = "Please try again";
    }
}

function checkAnswer2() {

    let num1 = parseInt(document.getElementById("num3").value);
    let num2 = parseInt(document.getElementById("num4").value);
    let result = parseInt(document.getElementById("result2").value);
    let messageElement = document.getElementById("message2");

    if (result == num1 - num2) {
        messageElement.innerHTML = "Correct";
    }
    else {
        messageElement.innerHTML = "Please try again";
    }
}

function checkAnswer3() {

    let num1 = parseInt(document.getElementById("num5").value);
    let num2 = parseInt(document.getElementById("num6").value);
    let result = parseInt(document.getElementById("result3").value);
    let messageElement = document.getElementById("message3");

    if (result == num1 * num2) {
        messageElement.innerHTML = "Correct";
    }
    else {
        messageElement.innerHTML = "Please try again";
    }
}

function checkAnswer4() {

    let num1 = parseInt(document.getElementById("num7").value);
    let num2 = parseInt(document.getElementById("num8").value);
    let result = parseInt(document.getElementById("result4").value);
    let messageElement = document.getElementById("message4");

    if (result == num1 / num2) {
        messageElement.innerHTML = "Correct";
    }
    else {
        messageElement.innerHTML = "Please try again";
    }
}

function checkAnswer5() {

    let num1 = parseInt(document.getElementById("num9").value);
    let num2 = parseInt(document.getElementById("num10").value);
    let result = parseInt(document.getElementById("result5").value);
    let messageElement = document.getElementById("message5");

    if (result == num1 % num2) {
        messageElement.innerHTML = "Correct";
    }
    else {
        messageElement.innerHTML = "Please try again";
    }
}