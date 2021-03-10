'use strict';

const customerInput = document.getElementById('customer-input');
const storeInput = document.getElementById('store-input');
const customerResult = document.getElementById('customer-result');
const storeSelection = document.getElementById('store');
const customer = document.getElementById('customer');
const store = document.getElementById('store-name');
const time = document.getElementById('time');
const productSelection = document.getElementById('products');
let customerId = 0;
let storeId = 0;


customerInput.addEventListener('submit', event => {
    event.preventDefault();
    const firstName = customerInput.elements['first'].value;
    const lastName = customerInput.elements['last'].value;
    getCustomer(firstName, lastName)
        .then(c => {
            customerId = c.customerId;
            customer.textContent = `Customer : ${firstName} ${lastName}`; 
        })
        .catch(error => {
            alert(error.toString());
        })
});


getStores()
    .then(stores => {
        for (const store of stores) {
            storeSelection.append(new Option(`${store.storeName}`));
        }
    });

//storeInput.addEventListener('click', event => {
//    event.preventDefault();

//    const stId = storeInput.elements['store-id'].value;
//    getStore(stId)
//        .then(s => {
//            storeId = s.storeId;
//            store.textContent = `Store : ${s.storeName}`;
//        })
//        .catch(error => {
//            alert(error.toString());
//        })
//    createOrder(customerId, storeId)
//        .then(order => {
//            time.textContent = `Time : ${order.orderDate}`;
//        });

//});

addMenuItems()
    .then(menu => {
        for (const item of menu) {
            productSelection.append(new Option(`${item.productName}`));
        }
    });

storeInput.addEventListener('click', event => {
    event.preventDefault();

    const stId = storeInput.elements['store-id'].value;
    getStore(stId)
        .then(s => {
            storeId = s.storeId;
            store.textContent = `Store : ${s.storeName}`;
        })
        .catch(error => {
            alert(error.toString());
        })
    createOrder(customerId, storeId)
        .then(order => {
            time.textContent = `Time : ${order.orderDate}`;
        });

});



