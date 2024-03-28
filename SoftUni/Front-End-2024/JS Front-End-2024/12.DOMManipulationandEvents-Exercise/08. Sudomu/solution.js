function solve() {
    const buttonElements = document.querySelector('table tfoot tr td').children;
    const rowElements = document.querySelectorAll('table tbody tr');

    let numbers = {}
    buttonElements[0].addEventListener('click', () => {
        let trElements = Array.from(rowElements);
        for(let i = 0; i < trElements.length; i++){
            console.log(Array.from(trElements[i].children).forEach(x=>
                console.log(x)
            ))
        }
    })
}