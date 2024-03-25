function colorize() {
    const tableEvenRowElements = document.querySelectorAll('tr:nth-child(2n)');

    for(const evenRow of tableEvenRowElements){
        evenRow.style.backgroundColor = 'teal';
    }

    console.log(tableEvenRowElements);
}