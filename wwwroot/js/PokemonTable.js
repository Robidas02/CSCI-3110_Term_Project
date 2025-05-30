﻿// This js file creates the Pokemon Index table.

'use strict';

import { PokemonRepository } from './PokemonRepository.js';

const pokeRepo = new PokemonRepository('/api/pokemon/all');

document.addEventListener('DOMContentLoaded', async () => {
    const pokemon = await pokeRepo.readAll();
    console.log(pokemon);
    populatePokemonTable(pokemon);
});


// Populates the table with the data from the database and an image from an external API.
function populatePokemonTable(pokemon) {
    const tableBody = document.getElementById('pokemonTableBody');
    tableBody.innerHTML = '';

    pokemon.forEach(mon => {
        let tr = document.createElement('tr');
        let td = document.createElement('td');
        td.textContent = mon.id;
        tr.appendChild(td);

        td = document.createElement('td');
        let img = document.createElement('img');
        img.src = `https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/versions/generation-viii/icons/${mon.dexNumber}.png`;
        img.width = 100;
        img.height = 100;
        td.appendChild(img);
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = mon.name;
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = convertTypeNumToName(mon.type1);
        tr.appendChild(td);

        td = document.createElement('td');
        td.textContent = convertTypeNumToName(mon.type2);
        tr.appendChild(td);

        tableBody.appendChild(tr);
    });
}

// Converts the number associated with each type to a human-readable string
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
