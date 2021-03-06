﻿
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
function getCustomer(first, last) {
    //debugger;
    return fetch(`api/search-customer/${first}/${last}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    }).then(response => {
        if (!response.ok) {
            throw new Error(`Customer cannot be added`);
        }
        return response.json();
    });
}
function addCustomer(customer) {
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

function getStores() {
    return fetch('/api/stores')
        .then(response => {
            return response.json();
        });
}

function getStore(id) {
    return fetch(`/api/get-store/${id}`)
        .then(response => {
            return response.json();
        }).then(response => {
            if (!response.ok) {
                throw new Error(`Store not in List`);
            }
        });
}

function createOrder(customerId, storeId) {
    return fetch(`/api/order/${customerId}/${storeId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
        return response.json();
}