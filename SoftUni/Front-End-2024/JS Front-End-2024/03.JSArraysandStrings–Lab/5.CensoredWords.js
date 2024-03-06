function solve(text, word){
    const pattern = new RegExp(word, 'g');
    let censored = text.replace(pattern, '*'.repeat(word.length));

    console.log(censored);
}

solve('A small sentence with some words small', 'small');