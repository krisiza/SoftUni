function solve() {
    const urlPresents = 'http://localhost:3030/jsonstore/gifts';

    const buttonLoadPresentsElement = document.querySelector('#load-presents');
    const divGitsListElement = document.querySelector('#gift-list');
    const giftElements = document.querySelectorAll('.gift-sock');
    const buttonAddGiftElement = document.querySelector('#add-present');
    const buttonEditGiftElement = document.querySelector('#edit-present');
    const inputGiftElement = document.querySelector('#gift');
    const inputForElement = document.querySelector('#for');
    const inputPriceElement = document.querySelector('#price');
    let currentid = null;

    Array.from(giftElements).forEach(g => g.remove());

    const updateGifts = async () => {
        try {
            // Fetch presents
            const response = await fetch(urlPresents);
            if (!response.ok) {
                throw new Error('Failed to load presents');
            }
            const presents = await response.json();

            // Clear existing gifts
            divGitsListElement.innerHTML = '';

            // Create and append new gift elements
            Object.values(presents).forEach(present => {
                const divSockElement = document.createElement('div');
                divSockElement.classList.add('gift-sock');

                const divContentElement = document.createElement('div');
                divContentElement.classList.add('content');

                const giftNamePElement = document.createElement('p');
                giftNamePElement.textContent = present.gift;
                divContentElement.appendChild(giftNamePElement);

                const personNamePElement = document.createElement('p');
                personNamePElement.textContent = present.for;
                divContentElement.appendChild(personNamePElement);

                const pricePElement = document.createElement('p');
                pricePElement.textContent = present.price;
                divContentElement.appendChild(pricePElement);

                divSockElement.appendChild(divContentElement);

                const divButtonsContainer = document.createElement('div');
                divButtonsContainer.classList.add('buttons-container');

                const buttonChangeElement = document.createElement('button');
                buttonChangeElement.textContent = 'Change';
                buttonChangeElement.classList.add('change-btn');
                buttonChangeElement.addEventListener('click', () => {
                    inputGiftElement.value = present.gift;
                    inputForElement.value = present.for;
                    inputPriceElement.value = present.price;
                    currentid = present._id;
                    buttonAddGiftElement.disabled = true;
                    buttonEditGiftElement.disabled = false;
                });

                const buttonDeleteElement = document.createElement('button');
                buttonDeleteElement.textContent = 'Delete';
                buttonDeleteElement.classList.add('delete-btn');
                buttonDeleteElement.addEventListener('click', async () => {
                    try {
                        const deleteResponse = await fetch(`${urlPresents}/${present._id}`, {
                            method: 'DELETE'
                        });
                        if (!deleteResponse.ok) {
                            throw new Error('Failed to delete gift');
                        }
                        await updateGifts();
                    } catch (error) {
                        console.error(error);
                    }
                });

                divButtonsContainer.appendChild(buttonChangeElement);
                divButtonsContainer.appendChild(buttonDeleteElement);
                divSockElement.appendChild(divButtonsContainer);
                divGitsListElement.appendChild(divSockElement);
            });
        } catch (error) {
            console.error(error);
        }
    };

    buttonLoadPresentsElement.addEventListener('click', updateGifts);

    buttonAddGiftElement.addEventListener('click', async () => {
        const response = await fetch(`${urlPresents}`, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({
                gift: inputGiftElement.value,
                for: inputForElement.value,
                price: inputPriceElement.value
            })
        });

        updateGifts();

        inputGiftElement.value = '';
        inputForElement.value = '';
        inputPriceElement.value = '';

    });

   // Edit gift
    buttonEditGiftElement.addEventListener('click', async () => {
    try {
        const response = await fetch(`${urlPresents}/${currentid}`, {
            method: 'PUT',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({
                gift: inputGiftElement.value,
                for: inputForElement.value,
                price: inputPriceElement.value,
                _id: currentid
            })
        });
        if (!response.ok) {
            throw new Error('Failed to edit gift');
        }

        await updateGifts();

        inputGiftElement.value = '';
        inputForElement.value = '';
        inputPriceElement.value = '';

        currentid = null;

        buttonAddGiftElement.disabled = false;
        buttonEditGiftElement.disabled = true;

    } catch (error) {
        console.error(error);
    }
});

}

solve();
