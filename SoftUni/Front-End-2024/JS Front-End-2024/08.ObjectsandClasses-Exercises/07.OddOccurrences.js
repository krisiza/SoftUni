function solve(input){

    let array = input.split(' ');
    let arrayWordRecords = [];
    let wordRecord = {};

    for(let wordToSearch of array){

        let foundWords = array.filter(x => x.toUpperCase() == wordToSearch.toUpperCase());
        let counter = foundWords.length;

        let word = wordToSearch;
        let foundWord = arrayWordRecords.find(x => x.wordToSearch.toUpperCase() === word.toUpperCase());

        if(!foundWord)
        {
            wordRecord = {
                wordToSearch,
            counter
            }

            arrayWordRecords.push(wordRecord);    
        }    
    }


    let output = arrayWordRecords.filter(x => x.counter % 2 !== 0)

    let outputStr = '';
    for(let element of output){
       outputStr += element.wordToSearch + ' ';
    }

    console.log(outputStr.toLowerCase());
    
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');