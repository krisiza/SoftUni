const baseUrl = `http://localhost:3030/jsonstore/games`;

const loadButtonElement = document.getElementById('load-games');
const listElement = document.getElementById('games-list');
const gameInputElement = document.getElementById('g-name');
const typeInputElement = document.getElementById('type');
const playersInputElement = document.getElementById('players');
const addButtonElement = document.getElementById('add-game');
const editButtonElement = document.getElementById('edit-game');

let currentId = null;

async function loadData(){
    listElement.innerHTML = '';

    const response = await fetch(baseUrl);
    const items = await response.json();

   for(let item of Object.values(items)){

        const changeButtonElement = document.createElement('button');
        changeButtonElement.textContent = 'Change';
        changeButtonElement.classList.add('change-btn');
        changeButtonElement.addEventListener('click', change);

        const deleteButtonElement = document.createElement('button');
        deleteButtonElement.textContent = 'Delete';
        deleteButtonElement.classList.add('delete-btn');
        deleteButtonElement.addEventListener('click', deleteItem);

        const containerButtonsElement = document.createElement('div');
        containerButtonsElement.id = 'buttons-container';
        containerButtonsElement.appendChild(changeButtonElement);
        containerButtonsElement.appendChild(deleteButtonElement);

        const gamePElement = document.createElement('p');
        gamePElement.textContent = item.name;
    
        const playersPElement = document.createElement('p');
        playersPElement.textContent = item.players;

        const typePElement = document.createElement('p');
        typePElement.textContent = item.type;

        const contentElement = document.createElement('div');
        contentElement.classList.add('content');
        contentElement.appendChild(gamePElement);
        contentElement.appendChild(playersPElement);
        contentElement.appendChild(typePElement);

        const boardGameElement = document.createElement('div');
        boardGameElement.classList.add('board-game');
        boardGameElement.appendChild(contentElement);
        boardGameElement.appendChild(containerButtonsElement);

        listElement.appendChild(boardGameElement);

        async function change(){
            boardGameElement.remove();

            gameInputElement.value = item.name;
            typeInputElement.value = item.type;
            playersInputElement.value = item.players

            currentId = item._id;

            editButtonElement.disabled = false;
            addButtonElement.disabled = true;
        }

        async function deleteItem(){

            const response = await fetch(`${baseUrl}/${item._id}`, {
                method: 'DELETE',
            })
        
            if(!response.ok){
                return;
            }

            boardGameElement.remove();
        }
   }
}

loadButtonElement.addEventListener('click', loadData);

addButtonElement.addEventListener('click', async() => {
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            name: gameInputElement.value,
            type: typeInputElement.value,
            players: playersInputElement.value,
        })
    });

    if(!response.ok){
        return;
    }

    loadData();

    gameInputElement.value = '';
    typeInputElement.value = '';
    playersInputElement.value = '';
})

editButtonElement.addEventListener('click', async () => {
    const response = await fetch(`${baseUrl}/${currentId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
             _id: currentId,
            name: gameInputElement.value,
            players: playersInputElement.value,
        })
    })

    if(!response.ok){
        return;
    }

    loadData();

    editButtonElement.disabled = true;
    addButtonElement.disabled = false;
    currentId = null;

    gameInputElement.value = '';
    typeInputElement.value = '';
    playersInputElement.value = '';
})