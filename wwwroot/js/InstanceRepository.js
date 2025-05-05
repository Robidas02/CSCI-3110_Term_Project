// Repo used for the createInstance and editInstance files.
'use strict'

export class InstanceRepository {
    #baseAddress;
    constructor(baseAddress) {
        this.#baseAddress = baseAddress;
    }

    // Reads all Pokemon objects from the database
    async readAllPokemon() {
        console.log("Attempting to retrieve all pokemon.")
        const response = await fetch(`/api/pokemon/all`);
        console.log(response);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json();
    };

    // Reads a single Pokemon object from the database
    async readSinglePokemon(id) {
        console.log("Attempting to retrieve a single mon.")
        const response = await fetch(`/api/pokemon/one/${id}`)
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json();
    }

    // Reads all Item objects from the database
    async readAllItems() {
        console.log("Attempting to retrieve all items.")
        const response = await fetch(`/api/item/all`);
        console.log(response);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json();
    };

    // Reads all Ability objects from the database 
    async readAllAbilities() {
        console.log("Attempting to retrieve all abilities.")
        const response = await fetch(`/api/ability/all`);
        console.log(response);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json();
    };

    // Reads all Move objects from the database
    async readAllMoves() {
        console.log("Attempting to retrieve all moves.")
        const response = await fetch(`/api/move/all`);
        console.log(response);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json();
    };
}