'use strict';

import { InstanceRepository } from './InstanceRepository.js';

const pIRepo = new InstanceRepository('/api/pokemoninstance/all');

document.addEventListener('DOMContentLoaded', async () => {
    const pokemon = await pIRepo.readAllPokemon();
    populatePokemonDropdown(pokemon);
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
        // Ensures that all dropdowns are populated with options after a Pokemon has been selected.
        let pokemon = await pIRepo.readSinglePokemon(selectedMon);
        await populateAbilityDropdown(pokemon.abilities);
        const items = await pIRepo.readAllItems();
        await populateItemDropdown(items);
        await populateMoveDropdown(pokemon.moves);

        // Fills the HTML for the tables that appear below the prompts
        monDetails.innerHTML = `
        <ul>
            <li><a class="btn btn-info" href="#abilityTable">Go to Abilities</a></li>
            <li><a class="btn btn-info" href="#itemTable">Go to Items</a></li>
            <li><a class="btn btn-info" href="#moveTable">Go to Moves</a></li>
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
        </div>
        <div>
            <h4 id="moveTable">Moves</h4>
            <table class="table">
                <thead>
                    <tr>
                        <td>Name</td>
                        <td>Type</td>
                        <td>Category</td>
                        <td>Power</td>
                        <td>Accuracy</td>
                        <td>Power Points</td>
                        <td>Description</td>
                    </tr>
                </thead>
                <tbody id="moveTableBody">
                </tbody>
            </table>
        </div>
        `;

        await populateAbilityTable(pokemon.abilities);
        await populateMoveTable(pokemon.moves);
        await populateItemTable(items);
    }
    catch (error) {
        monDetails.innerHTML = "<h3>An Error has Occurred</h3>";
        console.log(error);
    }
});

// Creates the HTML for the Pokemon's Move Selection
async function populateMoveDropdown(moves) {
    const dropdownsPlural = document.querySelectorAll('.moveDropdown');
    //dropdownsPlural.innerHTML = '';

    dropdownsPlural.forEach(dropdown => {
        let option = document.createElement('option');
        option.value = ``;
        option.textContent = 'Select a Move';
        console.log(option);
        dropdown.appendChild(option);

        moves.forEach(move => {
            option = document.createElement('option');
            option.value = move.id;
            option.textContent = move.name;
            dropdown.appendChild(option);
        });
    })
}

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


async function populateMoveTable(moves) {
    const tableBody = document.getElementById('moveTableBody');
    tableBody.innerHTML = '';

    moves.forEach(move => {
        let tr = document.createElement('tr');
        let td = document.createElement('td');
        td.textContent = move.name;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = convertTypeNumToName(move.type);
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = convertCategoryToName(move.category);
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = move.power;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = move.accuracy;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = move.powerPoints;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = move.description;
        tr.appendChild(td);

        tableBody.appendChild(tr);
    });
}

// Converts the number value for a Type to a string, so the user can actually see what it is.
function convertTypeNumToName(typeNum) {
    let type = '';
    switch (typeNum) {
        case 0:
            type = 'Normal';
            break;
        case 1:
            type = 'Fire';
            break;
        case 2:
            type = 'Water';
            break;
        case 3:
            type = 'Electric';
            break;
        case 4:
            type = 'Grass';
            break;
        case 5:
            type = 'Ice';
            break;
        case 6:
            type = 'Fighting';
            break;
        case 7:
            type = 'Poison';
            break;
        case 8:
            type = 'Ground';
            break;
        case 9:
            type = 'Flying';
            break;
        case 10:
            type = 'Psychic';
            break;
        case 11:
            type = 'Bug';
            break;
        case 12:
            type = 'Rock';
            break;
        case 13:
            type = 'Ghost';
            break;
        case 14:
            type = 'Dragon';
            break;
        case 15:
            type = 'Dark';
            break;
        case 16:
            type = 'Steel';
            break;
        case 17:
            type = 'Fairy';
            break;
        default:
            type = '';
            break;
    }
    return type;
}

// Converts the Cetegory number value to a string, so the user can know what category the move is.
function convertCategoryToName(catNum) {
    let cat = '';
    switch (catNum) {
        case 0:
            cat = 'Physical';
            break;
        case 1:
            cat = 'Special';
            break;
        case 2:
            cat = 'Status';
            break;
        default:
            cat = 'Error';
    }
    return cat;
}