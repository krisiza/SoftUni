function solve(text){

    let result = [];
    let word = '';
    word += text[0];

    for(let i = 1; i < text.length; i++)
    {
        if(text[i].match(/[a-z]/)){
            word += text[i];
        }else{
            result.push(word);
            word = '';
            word += text[i];
        }

    }
    result.push(word);

    let output = result.join(', ');
    console.log(output);
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');