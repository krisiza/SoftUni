window.addEventListener("load", solve);

function solve(){
    const buttonElement = document.querySelector('input[type=button]');
    const placeElement = document.querySelector('input[id=place]');
    const actionElement = document.querySelector('input[id=action]');
    const personElement = document.querySelector('input[id=person]');
    const tasksElement = document.querySelector('#task-list');
    const doneTasksElement = document.querySelector('#done-list');

    buttonElement.addEventListener('click', () => {
        if(placeElement.value !== '' && actionElement.value !== '' && personElement.value !== ''){
            const liElement = document.createElement('li');
            liElement.classList.add('clean-task');

            const pPlaceElement = document.createElement('p');
            pPlaceElement.textContent = 'Place:' + placeElement.value;

            const pActionElement = document.createElement('p');
            pActionElement.textContent = 'Action:' + actionElement.value;

            const pPersonElement = document.createElement('p');
            pPersonElement.textContent = 'Person:' +personElement.value;

            const divElement = document.createElement('div');
            divElement.classList.add('buttons');

            const editButtonElement = document.createElement('button');
            editButtonElement.textContent = 'Edit';
            editButtonElement.classList.add('edit');

            const doneButtonElement = document.createElement('button');
            doneButtonElement.textContent = 'Done';
            doneButtonElement.classList.add('done');

            divElement.appendChild(editButtonElement);
            divElement.appendChild(doneButtonElement);

            const articleElement = document.createElement('article');
            articleElement.appendChild(pPlaceElement);
            articleElement.appendChild(pActionElement);
            articleElement.appendChild(pPersonElement);

            liElement.appendChild(articleElement);
            liElement.appendChild(divElement);
            tasksElement.appendChild(liElement);

            placeElement.value = '';
            actionElement.value = '';
            personElement.value = '';

            editButtonElement.addEventListener('click', (e) => {
                const clickedLiElement = e.currentTarget.parentElement.parentElement;
                const firstpElement = clickedLiElement.querySelector('p:nth-of-type(1)');
                const secondpElement = clickedLiElement.querySelector('p:nth-of-type(2)');
                const thirdpElement = clickedLiElement.querySelector('p:nth-of-type(3)');

                placeElement.value = firstpElement.textContent.replace('Place:', '');
                actionElement.value = secondpElement.textContent.replace('Action:', '');
                personElement.value = thirdpElement.textContent.replace('Person:', '');

                console.log(clickedLiElement);
                clickedLiElement.remove();
            })

            doneButtonElement.addEventListener('click', (e) => {
                const clickedLiElement =  e.currentTarget.parentElement.parentElement;
                clickedLiElement.remove();
                doneTasksElement.appendChild(clickedLiElement);

                const divButtons = clickedLiElement.querySelector('.buttons');
                divButtons.remove();

                const deleteButtonElement = document.createElement('button');
                deleteButtonElement.textContent = 'Delete';
                deleteButtonElement.classList.add('delete');

                deleteButtonElement.addEventListener('click', () => {
                    clickedLiElement.remove();
                })

                clickedLiElement.appendChild(deleteButtonElement);
            })
        }
    })
}