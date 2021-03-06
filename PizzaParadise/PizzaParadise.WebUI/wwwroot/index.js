'use strict';

const menuItems = document.getElementById('menu');

function addMenuItems() {
    return fetch('/api/menu')
        .then(response => {
            return response.json();
        });
}
addMenuItems()
    .then(menu => {
        for (const item of menu) {
            const row = menuItems.insertRow();
            row.innerHTML = `<td>${item.id}</td>
                 <td>${item.name}</td>
                 <td>${item.price}</td>`;
        }
    });
