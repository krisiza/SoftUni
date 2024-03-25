function toggle() {
    const buttonElements = document.getElementsByClassName('button');
    const elemntToShow = document.getElementById("extra");

    if(elemntToShow.style.display === 'none'){
        elemntToShow.style.display = 'block';
        buttonElements[0].textContent = 'Less';
    }else{
        elemntToShow.style.display = 'none';
        buttonElements[0].textContent = 'More';
    }
}