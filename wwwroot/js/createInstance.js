'use strict'

import { InstanceRepository } from './InstanceRepository.js';

const pIRepo = new InstanceRepository('/api/pokemoninstance/all');

// Loads the Pokemon objects with the abilities and moves and gets the teamId
document.addEventListener('DOMContentLoaded', async () => {
    // Load everything
    const pokemon = await pIRepo.readAllPokemon();
    populatePokemonDropdown(pokemon);
    const teamId = document.getElementById("teamId").value;
    console.log(teamId)
});

// Populates the dropdown menu of pokemon
// Creates teh options inside the <select> element
function populatePokemonDropdown(pokemon) {
    const dropdown = document.getElementById("dropdownPokemon");
    dropdown.innerHTML = ''; // Clear the dropdown

    let option = document.createElement('option');
    option.value = '';
    option.textContent = 'Select Pokemon';
    console.log(option);
    dropdown.appendChild(option);

    pokemon.forEach(mon => {
        option = document.createElement('option');
        option.value = mon.id;
        option.textContent = mon.name;
        dropdown.appendChild(option);
    });
};

// Adds info to the create page when a pokemon is selected.
// This info is filtered to be accurate to the selected pokemon
document.getElementById('selectPokemon').addEventListener('click', async function (e) {
    e.preventDefault();
    const selectedMon = document.getElementById('dropdownPokemon').value;
    console.log(`This is the selected Pokemon: ${selectedMon}`);
    const monDetails = document.getElementById('pokeDetails');
    const monAbilities = document.getElementById('abilitiesAfterSelection');

    if (!selectedMon) {
        monDetails.innerHTML = "<h3>Please Select a Pokemon</h3>";
        monAbilities.innerHTML = "";
        return
    }

    // This part creates the details portion of the screen, so the user knows what each ability and item does.
    try {
        let pokemon = await pIRepo.readSinglePokemon(selectedMon);
        await populateAbilityDropdown(pokemon.abilities);
        const items = await pIRepo.readAllItems();
        await populateItemDropdown(items);

        monDetails.innerHTML = `
        <ul>
            <li><a class="btn btn-info" href="#abilityTable">Go to Abilities</a></li>
            <li><a class="btn btn-info" href="#itemTable">Go to Items</a></li>
        </ul>
        <br />
        <br />
        <br />
        <div>
            <h4 id="abilityTable">Abilities</h4>
            <table class="table">
                <thead>
                    <tr>
                        <td>Name</td>
                        <td>Description</td>
                    </tr>
                </thead>
                <tbody id="abilityTableBody">
                </tbody>
            </table>
        </div>
        <hr />
        <div>
            <h4 id="itemTable">Items</h4>
            <table class="table">
                <thead>
                    <tr>
                        <td>Name</td>
                        <td>Description</td>
                    </tr>
                </thead>
                <tbody id="itemTableBody">
                </tbody>
            </table>
        </div>`;

        await populateAbilityTable(pokemon.abilities);
        await populateItemTable(items);
    }
    catch (error) {
        monDetails.innerHTML = "<h3>An Error has Occurred</h3>";
        console.log(error);
    }
});

// Populates the options for the ability dropdown menu
// This data is filtered based on the selected Pokemon
async function populateAbilityDropdown(abilities) {
    const dropdown = document.getElementById("dropdownAbilities");
    dropdown.innerHTML = ''; // Clear the dropdown

    let option = document.createElement('option');
    option.value = '';
    option.textContent = 'Select Ability';
    console.log(option);
    dropdown.appendChild(option);

    abilities.forEach(ability => {
        option = document.createElement('option');
        option.value = ability.id;
        option.textContent = ability.name;
        dropdown.appendChild(option);
    });
};

// Populates the item dropdown menu with options from the item table
async function populateItemDropdown(items) {
    const dropdown = document.getElementById("dropdownItems");
    dropdown.innerHTML = ''; // Clear the dropdown

    let option = document.createElement('option');
    option.value = '';
    option.textContent = 'Select Item';
    console.log(option);
    dropdown.appendChild(option);

    items.forEach(item => {
        option = document.createElement('option');
        option.value = item.id;
        option.textContent = item.name;
        dropdown.appendChild(option);
    });
};

// Populates the table from the main function with the filtered ability data
async function populateAbilityTable(abilities) {
    const tableBody = document.getElementById('abilityTableBody');
    tableBody.innerHTML = '';

    abilities.forEach(ability => {
        let tr = document.createElement('tr');
        let td = document.createElement('td');
        td.textContent = ability.name;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = ability.description;
        tr.appendChild(td);

        tableBody.appendChild(tr);
    });
}

// Populates the table from teh main function with the item data
// Item data isn't filtered because any Pokemon can use any item
async function populateItemTable(items) {
    const tableBody = document.getElementById('itemTableBody');
    tableBody.innerHTML = '';

    items.forEach(item => {
        let tr = document.createElement('tr');
        let td = document.createElement('td');
        td.textContent = item.name;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = item.description;
        tr.appendChild(td);

        tableBody.appendChild(tr);
    });
}

