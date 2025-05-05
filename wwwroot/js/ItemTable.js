// This js file creates the Item Index table.

'use strict';

import { ItemRepository } from './ItemRepository.js';

const itemRepo = new ItemRepository('/api/item/all');

document.addEventListener('DOMContentLoaded', async () => {
    const items = await itemRepo.readAll();
    console.log(items);
    populatePokemonTable(items);
});


// Populates the table with the data from the database.
function populatePokemonTable(items) {
    const tableBody = document.getElementById('itemTableBody');
    tableBody.innerHTML = '';

    items.forEach(item => {
        let tr = document.createElement('tr');
        let td = document.createElement('td');
        td.textContent = item.id;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = item.name;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = item.description;
        tr.appendChild(td);

        tableBody.appendChild(tr);
    });
}