var inputSizes = {
    CardNr: 4,
    Cvv: 3,
    Blik: 1
};

var inputLengths = {
    CardNr: 4,
    Blik: 6
}

initPaymentPage();

function initPaymentPage() {
    createForm();
    initCreditCardForm();
    initSelectListener();
    initializeValidation();
}

function initSelectListener() {
    let selectDiv = document.getElementById('payment');
    selectDiv.addEventListener('change', setForm);
}

function setForm() {
    let select = document.getElementById('payment');
    let bankTransferDiv = document.getElementById('bankTransferDiv');
    let blikDiv = document.getElementById('blikDiv');
    let creditCardDiv = document.getElementById('creditCardDiv');

    if (select.value === "Credit card") {
        blikDiv.textContent = '';
        bankTransferDiv.textContent = '';
        initCreditCardForm();
    }
    else if (select.value === "Bank transfer") {
        blikDiv.textContent = '';
        creditCardDiv.textContent = '';
        initBankTransferForm();
    }
    else if (select.value === "BLIK") {
        creditCardDiv.textContent = '';
        bankTransferDiv.textContent = '';
        initBlikForm();
    }
}

function createForm() {
    let paymentContainer = document.getElementById('paymentContainer');
    createNewPaymentDiv(paymentContainer, "blikDiv");
    createNewPaymentDiv(paymentContainer, "creditCardDiv");
    createNewPaymentDiv(paymentContainer, "bankTransferDiv");
}

function createNewPaymentDiv(paymentContainer, divName) {
    let newDiv = document.createElement("div");
    newDiv.id = divName;
    newDiv.className = "container";
    paymentContainer.appendChild(newDiv);
}

function initCreditCardForm() {
    let creditCardDiv = document.getElementById('creditCardDiv');
    let error = document.createElement("p");
    error.id = "cardNumberError";
    let cardNumberMessage = document.createElement("p");
    cardNumberMessage.innerText = "Enter your Credit card number:";
    creditCardDiv.appendChild(cardNumberMessage);

    for (var i = 0; i < inputLengths.CardNr; i++) {
        createCardNumberInput(creditCardDiv);
    }
    creditCardDiv.appendChild(error);
    createDateInput(creditCardDiv);
    createCvvInput(creditCardDiv);
}

function createCardNumberInput(creditCardDiv) {
    let codeInput = document.createElement("input");
    codeInput.name = "creditCardNumber";
    defineInputSize(codeInput, inputSizes.CardNr);
    codeInput.placeholder = "----";
    creditCardDiv.appendChild(codeInput);
    codeInput.addEventListener('keyup', errorMessage);
}

function createDateInput(creditCardDiv) {
    let dateInput = document.createElement("input");
    let dateText = document.createElement("p");
    dateText.innerText = "Enter expiration date:";
    dateInput.required = true;
    dateInput.id = "date";
    dateInput.name = "date";
    dateInput.type = "date";
    var currentDate = new Date().toJSON().slice(0, 10);
    dateInput.min = currentDate;
    creditCardDiv.appendChild(dateText);
    creditCardDiv.appendChild(dateInput);
}

function createCvvInput(creditCardDiv) {
    let cvvInfo = document.createElement("p");
    let cvvInput = document.createElement("input");
    let error = document.createElement("p");
    cvvInput.addEventListener('keyup', errorMessage);
    error.id = "cvvError";
    cvvInfo.innerText = "Enter your CVV/CVC code:";
    cvvInput.name = "creditCardCvv";
    cvvInput.id = "creditCardCvv";
    cvvInput.required = true;
    defineInputSize(cvvInput, inputSizes.Cvv);
    cvvInput.placeholder = "---";
    creditCardDiv.appendChild(cvvInfo);
    creditCardDiv.appendChild(cvvInput);
    creditCardDiv.appendChild(error);
}

function defineInputSize(div, size) {
    div.minLength = size;
    div.maxLength = size;
    div.size = size;
}

function initBlikForm() {
    let blikDiv = document.getElementById('blikDiv');
    let error = document.createElement("p");
    error.id = "blikError";
    blikDiv.innerText = "Enter your BLIK code:";
    for (var i = 0; i < inputLengths.Blik; i++) {
        let codeInput = document.createElement("input");
        codeInput.name = "blikNumber";
        codeInput.required = true;
        defineInputSize(codeInput, inputSizes.Blik);
        codeInput.placeholder = "-";
        codeInput.addEventListener('keyup', errorMessage);
        blikDiv.appendChild(codeInput);
    }
    blikDiv.appendChild(error);
}

function initBankTransferForm() {
    let bankTransferDiv = document.getElementById('bankTransferDiv');
    let description = document.createElement("p");
    description.innerText = "Choose your bank:";
    let bankList = ["mBank", "Santander Bank", "Millennium Bank", "BNP Paribas"];
    let selectList = document.createElement("select");
    selectList.id = "mySelect";
    bankTransferDiv.appendChild(description);
    bankTransferDiv.appendChild(selectList);

    for (var i = 0; i < bankList.length; i++) {
        let option = document.createElement("option");
        option.value = bankList[i];
        option.text = bankList[i];
        selectList.appendChild(option);
    }
}

function errorMessage(event) {
    let eventTarget = event.target;

    if (eventTarget.name === "creditCardNumber") {
        HandleInputErrors('cardNumberError', "Please enter a valid card number!", "creditCardNumber");
    }
    else if (eventTarget.name === "creditCardCvv") {
        HandleInputErrors('cvvError', "Please enter a valid CVV number!", "creditCardCvv");
    }
    else if (eventTarget.name === "blikNumber") {
        HandleInputErrors('blikError', "Please enter a valid BLIK number!", "blikNumber");
    }
}

function HandleInputErrors(errorId, message, targetName) {
    let allElements = document.getElementsByName(targetName);
    let errorDiv = document.getElementById(errorId);
    let possibleErrors = allElements.length;
    for (var i = 0; i < allElements.length; i++) {
        if (isNaN(allElements[i].value)) {
            allElements[i].style.color = "red";
            if (errorDiv.textContent === "") {
                displayErrorMessage(errorDiv, message);
            }
        }
        else {
            allElements[i].style.color = "black";
            possibleErrors -= 1;
        }
    }
    if (possibleErrors === 0) {
        errorDiv.textContent = "";
    }
}

function displayErrorMessage(errorDiv, message) {
    errorDiv.textContent = message;
    errorDiv.style.fontSize = "20px";
    errorDiv.style.fontWeight = "bold";
    errorDiv.style.color = "red";
}

function initializeValidation() {
    let button = document.getElementById('payButton');
    button.addEventListener('click', validate);
}

function validate() {
    let isCardNrValid = false;
    let isCvvValid = false;
    let isBlikValid = false;
    let cardNumberError = document.getElementById('cardNumberError');
    let cvvError = document.getElementById('cvvError');
    let blikError = document.getElementById('blikError');

    if (cardNumberError != null) {
        if (cardNumberError.innerText === "") {
            isCardNrValid = true;
        }
        if (cvvError.innerText === "") {
            isCvvValid = true;
        }
        if (!isCardNrValid || !isCvvValid) {
            event.preventDefault();
            event.stopPropagation();
        }
    }
    else if (blikError != null) {
        if (blikError.innerText === "") {
            isBlikValid = true;
        }
        if (!isBlikValid) {
            event.preventDefault();
            event.stopPropagation();
        }
    }
}

