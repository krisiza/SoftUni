function extractText() {
    const itemsElement = document.getElementById('items');
    const textAreaElement = document.getElementById('result');

    textAreaElement.textContent = itemsElement.textContent;    
}