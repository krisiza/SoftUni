window.addEventListener("load", solve);

function solve(){
    const expenseInputElement = document.getElementById('expense');
    const amaountInputElement = document.getElementById('amount');
    const dateInputElement = document.getElementById('date');
    const addButtonElement = document.getElementById('add-btn');
    const previewListElement = document.getElementById('preview-list');
    const expensesListElement = document.getElementById('expenses-list');
    const deleteButtonElement = document.getElementsByClassName('delete');

    addButtonElement.addEventListener('click', () => {

        if(expenseInputElement.value === '' || amaountInputElement.value === '' || dateInputElement.value === ''){
            return;
        }

        const expenseItemElement = document.createElement('li');
        expenseItemElement.classList.add('expense-item');

        const articleElement = document.createElement('article');

        const typePElement = document.createElement('p');
        typePElement.textContent = `Type: ${expenseInputElement.value}`;
        articleElement.appendChild(typePElement);

        const amaoutPElement = document.createElement('p');
        amaoutPElement.textContent = `Amount: ${amaountInputElement.value}$`;
        articleElement.appendChild(amaoutPElement);

        const datePElement = document.createElement('p');
        datePElement.textContent = `Date: ${dateInputElement.value}`;
        articleElement.appendChild(datePElement);

        expenseItemElement.appendChild(articleElement);

        const buttonsDivElement = document.createElement('div');
        buttonsDivElement.classList.add('buttons');

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('btn');
        editButtonElement.classList.add('edit');
        editButtonElement.textContent = 'edit';

        editButtonElement.addEventListener('click', () => {
            expenseInputElement.value = typePElement.textContent.replace('Type: ', '');
            amaountInputElement.value = amaoutPElement.textContent.replace('Amount: ', '').replace('$', '');
            dateInputElement.value = datePElement.textContent.replace('Date: ', '');

            expenseItemElement.remove();
            addButtonElement.disabled = false;
        })

        buttonsDivElement.appendChild(editButtonElement);

        const okButtonElement = document.createElement('button');
        okButtonElement.classList.add('btn');
        okButtonElement.classList.add('ok');
        okButtonElement.textContent = 'ok';

        okButtonElement.addEventListener('click', () => {
            expenseItemElement.remove();
            expensesListElement.appendChild(expenseItemElement);

            buttonsDivElement.remove();
            addButtonElement.disabled = false;
        })

        buttonsDivElement.appendChild(okButtonElement);

        expenseItemElement.appendChild(buttonsDivElement);

        previewListElement.appendChild(expenseItemElement);

        expenseInputElement.value = '';
        amaountInputElement.value = '';
        dateInputElement.value = '';

        addButtonElement.disabled = true;
    })

    deleteButtonElement[0].addEventListener('click', () => {
        expensesListElement.innerHTML = '';
    })
}