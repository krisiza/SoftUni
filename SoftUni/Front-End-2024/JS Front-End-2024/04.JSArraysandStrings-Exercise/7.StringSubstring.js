function solve(word, text){
    wordsArray = text.toLowerCase().split(' ');

    const isIncluded = wordsArray.includes(word.toLowerCase());

    if(isIncluded){
        console.log(word);
        return;
    }

    console.log(`${word} not found!`);
}

solve('javascript',
'JavaScript is the best programming language'
);