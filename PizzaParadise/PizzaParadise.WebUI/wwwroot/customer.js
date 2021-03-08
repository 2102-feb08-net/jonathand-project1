'use strict';

const customerInput = document.getElementById('customer-input');
const errorMessage = document.getElementById('error-message');
const successMessage = document.getElementById('success-message');
const customerList = document.getElementById('customer-list');

getCustomers()
    .then(customers => {
        for (const customer of customers) {
            const row = customerList.insertRow();
            row.innerHTML = `<td>${customer.firstName}</td>
                 <td>${customer.lastName}</td>`;
        }
    });

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
            const row = customerList.insertRow();
            row.innerHTML = `<td>${customer.firstName}</td>
                 <td>${customer.lastName}</td>`;
        })
        .catch(error => {
            errorMessage.textContent = error.toString();
            errorMessage.hidden = false;
        })
});



