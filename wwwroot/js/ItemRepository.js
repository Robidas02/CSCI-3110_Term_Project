// Repo used for the item table js file
'use strict'

export class ItemRepository {
    #baseAddress;
    constructor(baseAddress) {
        this.#baseAddress = baseAddress;
    }

    async readAll() {
        console.log("Attempting to retrieve all items.")
        const response = await fetch(`/api/item/all`);
        console.log(response);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return await response.json();
    };
}