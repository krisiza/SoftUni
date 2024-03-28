function focused() {
    const inputElements = document.querySelectorAll('input[type=text]');

    Array.from(inputElements).forEach(inputElement => {
        inputElement.addEventListener('focus', () => {
            inputElement.parentElement.classList.add('focused');
        })

        inputElement.addEventListener('blur', () =>{
            inputElement.parentElement.classList.remove('focused');
        })
    })
}