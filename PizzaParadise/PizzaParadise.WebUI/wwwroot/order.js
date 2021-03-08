'use strict';

const customerInput = document.getElementById('customer-input');
const errorMessage = document.getElementById('error-message');
const successMessage = document.getElementById('success-message');
const customerResult = document.getElementById('customer-result');

customerInput.addEventListener('submit', event => {
    event.preventDefault();
    successMessage.hidden = true;
    errorMessage.hidden = true;

    const firstName = customerInput.elements['first'].value;
    const lastName = customerInput.elements['last'].value;
    
    getCustomer(firstName, lastName)
        .then(customer => {
            successMessage.textContent = 'Customer Exists!';
            successMessage.hidden = false;
        })
        .catch(error => {
            errorMessage.textContent = error.toString();
            errorMessage.hidden = false;
        })
});

