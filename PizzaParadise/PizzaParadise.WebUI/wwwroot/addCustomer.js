'use strict';

const customerInput = document.getElementById('customer-input');
const errorMessage = document.getElementById('error-message');
const successMessage = document.getElementById('success-message');

function addCustomer(customer) {
    return fetch('/api/add-customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    }).then(response => {
        if (!response.ok) {
            throw new Error(`Network response was not ok (${response.status})`);
        }
    });
}

customerInput.addEventListener('submit', event => {
            event.preventDefault();

            successMessage.hidden = true;
            errorMessage.hidden = true;

            const customer = {
                firstName: customerInput.elements['first'].value,
                lastName: customerInput.elements['last'].value,
            };

            addCustomer(customer)
                .then(() => {
                    successMessage.textContent = 'Customer added sent successfully';
                    successMessage.hidden = false;
                })
                .catch(error => {
                    errorMessage.textContent = error.toString();
                    errorMessage.hidden = false;
                });
});
