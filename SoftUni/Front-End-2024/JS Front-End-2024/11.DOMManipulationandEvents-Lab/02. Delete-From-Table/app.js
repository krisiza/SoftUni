function deleteByEmail() {
    const inputElement = document.querySelector('input[name=email]');
    const resultElement = document.getElementById('result');
    const tdElements = document.querySelectorAll('table tbody tr');

    let deleted = false;
    for(const item of Array.from(tdElements)){
        if(item.children[1].textContent.includes(inputElement.value)){
            item.remove();
            resultElement.textContent = "Deleted.";
            deleted = true;
        }
    }

    if(!deleted){
        resultElement.textContent = "Not found.";
    }

    inputElement.value = '';
}