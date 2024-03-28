function addItem() {
    const inputElement = document.getElementById('newItemText');
    const listElement = document.getElementById('items');

    const newElement = document.createElement('li');
    newElement.textContent = inputElement.value;
    listElement.appendChild(newElement);

    const aElement = document.createElement('a');
    aElement.textContent = '[Delete]';
    aElement.href = '#';
    newElement.appendChild(aElement);

    aElement.addEventListener('click', () =>{
        newElement.remove();
    })

    inputElement.value = '';
}