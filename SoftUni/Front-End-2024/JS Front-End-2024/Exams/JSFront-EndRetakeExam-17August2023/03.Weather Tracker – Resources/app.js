const baseUrl = `http://localhost:3030/jsonstore/tasks`;

const loadButtonElement = document.getElementById('load-history');
const listElement = document.getElementById('list');
const locationInputElement = document.getElementById('location');
const temperatureInputElement = document.getElementById('temperature');
const dateInputElement = document.getElementById('date');
const addButtonElement = document.getElementById('add-weather');
const editButtonElement = document.getElementById('edit-weather');

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

        const h2Element = document.createElement('h2');
        h2Element.textContent = item.location;
    
        const h3FistElement = document.createElement('h3');
        h3FistElement.textContent = item.temperature;

        const h3SecondElement = document.createElement('h3');
        h3SecondElement.textContent = item.date;

        const containerItemElement = document.createElement('div');
        containerItemElement .classList.add('container');
        containerItemElement .appendChild(h2Element);
        containerItemElement .appendChild(h3FistElement);
        containerItemElement .appendChild(h3SecondElement);
        containerItemElement .appendChild(containerButtonsElement);

        listElement.appendChild(containerItemElement);

        async function change(){
            containerItemElement.remove();

            locationInputElement.value = item.location;
            temperatureInputElement.value = item.temperature;
            dateInputElement.value = item.date;

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

            containerItemElement.remove();
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
            location: locationInputElement.value,
            temperature: temperatureInputElement.value,
            date: dateInputElement.value,
        })
    });

    if(!response.ok){
        return;
    }

    loadData();

    locationInputElement.value = '';
    temperatureInputElement.value = '';
    dateInputElement.value = '';
})

editButtonElement.addEventListener('click', async () => {
    const response = await fetch(`${baseUrl}/${currentId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
             _id: currentId,
            location: locationInputElement.value,
            temperature: temperatureInputElement.value,
            date: dateInputElement.value,
        })
    })

    if(!response.ok){
        return;
    }

    loadData();

    editButtonElement.disabled = true;
    addButtonElement.disabled = false;
    currentId = null;

    locationInputElement.value = '';
    temperatureInputElement.value = '';
    dateInputElement.value = '';
})
