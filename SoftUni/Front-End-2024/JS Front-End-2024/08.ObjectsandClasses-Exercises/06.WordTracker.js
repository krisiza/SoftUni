function solve(input){

    let arrayWord = input.shift().split(' ');

    let arrayWordRecords = [];
    let wordRecord = {};

    for(let word of arrayWord){

        let foundWords = input.filter(x => x == word);
      
        let counter = foundWords.length;
        wordRecord = {
            word,
            counter
        }

        arrayWordRecords.push(wordRecord);          
    }

    arrayWordRecords.sort((a,b) => b.counter - a.counter);

    for(let element of arrayWordRecords){
        console.log(`${element.word} - ${element.counter}`); 
    }   
}

solve([
    'is the', 
    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence'])