function addItem() {
    const inputElement = document.getElementById('newItemText');
    const listElement = document.getElementById('items');

    const newElement = document.createElement('li');
    newElement.textContent = inputElement.value;
    listElement.appendChild(newElement);
    inputElement.value = '';
}