function validate() {
    const inputElement = document.getElementById('email');

    const format = /^[a-z]+@[a-z]+\.[a-z]+/;

    inputElement.addEventListener('change', ()=>{
        if(!format.test(inputElement.value)){
            inputElement.classList.add('error');
        }else{
            inputElement.classList.remove('error');
        }
    })
}