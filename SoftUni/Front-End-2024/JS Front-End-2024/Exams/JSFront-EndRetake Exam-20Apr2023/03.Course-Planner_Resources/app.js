const baseUrl = `http://localhost:3030/jsonstore/tasks`;

const titleInputElement = document.getElementById('course-name');
const typeInputElement = document.getElementById('course-type');
const descriptionInputElement = document.getElementById('description');
const teacherNameInputElement = document.getElementById('teacher-name')
const addButtonElement = document.getElementById('add-course');
const editBaseButtonElement = document.getElementById('edit-course');
const loadButttonElement = document.getElementById('load-course');
const listElement = document.getElementById('list');
const formElement = document.getElementById('form');

async function loadData(){
    listElement.innerHTML = '';

    const response = await fetch(baseUrl);
    const items = await response.json();

   for(let item of Object.values(items)){

        const editButtonElement = document.createElement('button');
        editButtonElement.textContent = 'Edit Course';
        editButtonElement.classList.add('edit-btn');
        editButtonElement.addEventListener('click', edit);

        const finishButtonElement = document.createElement('button');
        finishButtonElement.textContent = 'Finish Course';
        finishButtonElement.classList.add('finish-btn');
        finishButtonElement.addEventListener('click', finishCourse);

        const h2Element = document.createElement('h2');
        h2Element.textContent = item.title;
    
        const h3FistElement = document.createElement('h3');
        h3FistElement.textContent = item.teacher;

        const h3SecondElement = document.createElement('h3');
        h3SecondElement.textContent = item.type;

        const h4Element = document.createElement('h3');
        h4Element.textContent = item.description;

        const containerItemElement = document.createElement('div');
        containerItemElement .classList.add('container');
        containerItemElement .appendChild(h2Element);
        containerItemElement .appendChild(h3FistElement);
        containerItemElement .appendChild(h3SecondElement);
        containerItemElement .appendChild(h4Element);
        containerItemElement .appendChild(editButtonElement);
        containerItemElement .appendChild(finishButtonElement);

        listElement.appendChild(containerItemElement);

        async function edit(){
            containerItemElement.remove();

            formElement.setAttribute('data-id', item._id);

            titleInputElement.value = item.title;
            typeInputElement.value = item.type;
            descriptionInputElement.value = item.description;
            teacherNameInputElement.value = item.teacher;

            editBaseButtonElement.disabled = false;
            addButtonElement.disabled = true;
        }

        async function finishCourse(){

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

loadButttonElement.addEventListener('click', loadData);

addButtonElement.addEventListener('click', async () => {

    if(typeInputElement.value === 'Long' || 
    typeInputElement.value === 'Medium' ||
    typeInputElement.value === 'Short'){
        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify({
                title: titleInputElement.value,
                type: typeInputElement.value,
                description: descriptionInputElement.value,
                teacher: teacherNameInputElement.value
            })
        });
    
    
        loadData();
    
        titleInputElement.value = '';
        typeInputElement.value = '';
        descriptionInputElement.value = '';
        teacherNameInputElement.value = '';
    }
    
})

editBaseButtonElement.addEventListener('click', async(e) => {
    let id = e.currentTarget.parentElement.parentElement.getAttribute('data-id');
    const response = await fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
             _id: id,
            title: titleInputElement.value,
            type: typeInputElement.value,
            description: descriptionInputElement.value,
            teacher: teacherNameInputElement.value
        })
    })

    if(!response.ok){
        return;
    }

    loadData();

    editBaseButtonElement.disabled = true;
    addButtonElement.disabled = false;

    titleInputElement.value = '';
    typeInputElement.value = '';
    descriptionInputElement.value = '';
    teacherNameInputElement.value = '';
})

