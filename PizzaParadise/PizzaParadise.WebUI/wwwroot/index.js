'use strict';

const menuItems = document.getElementById('menuitems');
const drinkItems = document.getElementById('drinkitems');

//debugger;
addMenuItems()
    .then(menu => {
        for (const item of menu) {
            const row = menuItems.insertRow();
            if (item.productId < 13) {
                row.innerHTML = `<td>${item.productId}</td>
                 <td>${item.productName}</td>
                 <td>${item.productPrice}</td>`;
            }
            else {
                const row = drinkItems.insertRow();
                row.innerHTML = `<td>${item.productId}</td>
                 <td>${item.productName}</td>
                 <td>${item.productPrice}</td>`;
            }
        }
    });
