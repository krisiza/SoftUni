function solve(words,text){
    let arrayWithWords = words.split(', ');

    for(let i = 0; i < arrayWithWords.length; i++){
        let wordToReplace = '*'.repeat(arrayWithWords[i].length);
        text = text.replace(wordToReplace, arrayWithWords[i]);
    }

    console.log(text);
}

solve('great, learning',
'softuni is ***** place for ******** new programming languages'
)