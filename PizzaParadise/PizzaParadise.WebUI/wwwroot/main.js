
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
    return fetch(`api/search-customer/${first}/${last}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    }).then(response => {
        if (!response.ok) {
            throw new Error(`Customer not in List`);
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