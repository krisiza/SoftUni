const url = 'http://localhost:3030/jsonstore/tasks';

const loadMealButtonElement = document.getElementById('load-meals');
const addMealButtonElement = document.getElementById('add-meal');
const editMealButtonElement = document.getElementById('edit-meal');
const mealsListElement = document.getElementById('list');
const foodInputElement = document.getElementById('food');
const timeInputElement = document.getElementById('time');
const caloriesInputElement = document.getElementById('calories');
let cuurentId = null;

const loadData = async () => {
    const response = await fetch(url);
    const meals = await response.json();

    mealsListElement.innerHTML = '';

   for(let meal of Object.values(meals)){

    const changeMealButtonElement = document.createElement('button');
    changeMealButtonElement.textContent = 'Change';
    changeMealButtonElement.classList.add('change-meal');

    const deleteMealButtonElement = document.createElement('button');
    deleteMealButtonElement.textContent = 'Delete';
    deleteMealButtonElement.classList.add('delete-meal');

    const divMealButtonsElement = document.createElement('div');
    divMealButtonsElement.id = 'meal-buttons';
    divMealButtonsElement.appendChild(changeMealButtonElement);
    divMealButtonsElement.appendChild(deleteMealButtonElement);
    
    const h2Element = document.createElement('h2');
    h2Element.textContent = meal.food;
    
    const h3TimeElement = document.createElement('h3');
    h3TimeElement.textContent = meal.time;

    const h3CaloriesElement = document.createElement('h3');
    h3CaloriesElement.textContent = meal.calories;

    const divMealElement = document.createElement('div');
    divMealElement.classList.add('meal');
    divMealElement.appendChild(h2Element);
    divMealElement.appendChild(h3TimeElement);
    divMealElement.appendChild(h3CaloriesElement);
    divMealElement.appendChild(divMealButtonsElement);

    mealsListElement.appendChild(divMealElement);

    changeMealButtonElement.addEventListener('click',() => {
        cuurentId = meal._id;

        foodInputElement.value = meal.food;
        timeInputElement.value = meal.time;
        caloriesInputElement.value = meal.calories;

        editMealButtonElement.removeAttribute('disabled');
        addMealButtonElement.setAttribute('disabled', 'disabled');

        divMealElement.remove();
    })

    // Attach on delete
    deleteMealButtonElement.addEventListener('click', async () => {
        // delete http request
        await fetch(`${url}/${meal._id}`, {
            method: 'DELETE'
        });

        // remove from list
        divMealElement.remove();      
    });
}
}

loadMealButtonElement.addEventListener('click',loadData)

addMealButtonElement.addEventListener('click',async () => {
    const newMeal = getInputData();

   // create post request
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(newMeal),
    });

    if (!response.ok) {
        return;
    }
    
    
    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';
    
    loadData();
})

editMealButtonElement.addEventListener('click', async() => {
    const { food, calories, time } = getInputData();

    const response = await fetch(`${url}/${cuurentId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
             _id: cuurentId,
            food,
            calories,
            time,
        })
    });

    if(!response.ok){
        return;
    }

    editMealButtonElement.setAttribute('disabled', 'disabled');
    addMealButtonElement.removeAttribute('disabled');
    
    cuurentId = null;

    
    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';

    loadData();
})

function getInputData() {
    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;

    return { food, time, calories };
}