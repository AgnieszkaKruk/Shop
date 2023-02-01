
document.onload = getTotalValue();

function getTotalValue() {
    let button = document.getElementById('productsValue');
    let totalValue = button.innerText;

    $.ajax({
        url: 'Product/PaymentPage',
        data: JSON.stringify(totalValue),
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json'
    });
}