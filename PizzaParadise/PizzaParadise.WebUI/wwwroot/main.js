﻿function addCustomer(customer) {
    return fetch('/api/add-customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    }).then(response => {
        if (!response.ok) {
            throw new Error(`Customer cannot be added`);
        }
    });
}

function getCustomers() {
    return fetch('/api/customers')
        .then(response => {
            return response.json();
        });
}

function addMenuItems() {
    return fetch('/api/products')
        .then(response => {
            return response.json();
        });
}

function addCustomer(first, last) {
    return fetch('api/search-customer/{first,last}')
        .then(response => {
            if (!response.ok) {
                throw new Error(`Customer not in list`);
            }
            else {
                return response.json();
            }
        });
}