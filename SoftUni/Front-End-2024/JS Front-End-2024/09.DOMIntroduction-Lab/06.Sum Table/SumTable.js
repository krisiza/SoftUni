function sumTable() {
    const tableElements = document.querySelectorAll('tbody tr td:nth-child(2n):not(#sum)');
    const tdSumElement = document.querySelector('#sum');

    let sum = 0;
    for(const element of tableElements){
        sum += Number(element.textContent);
    }

    tdSumElement.textContent = sum;
}