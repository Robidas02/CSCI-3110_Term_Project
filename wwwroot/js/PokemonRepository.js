'use strict'

export class PokemonRepository {
    #baseAddress;
    constructor(baseAddress) {
        this.#baseAddress = baseAddress;
    }

    async readAll() {
        console.log("Attempting to retrieve all pokemon.")
        const response = await fetch(`/api/pokemon/all`);
        console.log(response);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json();
    };
}