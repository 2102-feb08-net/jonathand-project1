'use strict';

const customerInput = document.getElementById('customer-input');
const errorMessage = document.getElementById('error-message');
const successMessage = document.getElementById('success-message');
const customerResult = document.getElementById('customer-result');
const storeSelection = document.getElementById('store');
let customerId = 0;
let storeId = 0;


customerInput.addEventListener('submit', event => {
    event.preventDefault();
    successMessage.hidden = true;
    errorMessage.hidden = true;
    const firstName = customerInput.elements['first'].value;
    const lastName = customerInput.elements['last'].value;
    getCustomer(firstName, lastName)
        .then(c => {
            successMessage.textContent = 'Customer Exists!';
            successMessage.hidden = false;
            customerId = c.customerId;
        })
        .catch(error => {
            errorMessage.textContent = error.toString();
            errorMessage.hidden = false;
        })
    getStores()
        .then(stores => {
            for (const store of stores) {
                storeSelection.innerHTML += `<option value="${store.storeId}">${store.storeName}</option>`;
            }
            storeSelection.addEventListener('click', () => {
                sessionStorage.setItem('storeId', store.storeId);
            })
            //debugger;
            storeId = sessionStorage.getItem('storeId');
        });
});


