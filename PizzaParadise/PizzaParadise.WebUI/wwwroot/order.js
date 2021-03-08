'use strict';

const customerInput = document.getElementById('customer-input');
const errorMessage = document.getElementById('error-message');
const successMessage = document.getElementById('success-message');


customerInput.addEventListener('submit', event => {
    event.preventDefault();
    successMessage.hidden = true;
    errorMessage.hidden = true;

    const firstName = customerInput.elements['first'].value;
    const lastName = customerInput.elements['last'].value;
    getCustomer(firstName, lastName)
        .then(customer => {
            const row = menuItems.insertRow();
            row.innerHTML = `<p>${item.productId}</p>
        });
});