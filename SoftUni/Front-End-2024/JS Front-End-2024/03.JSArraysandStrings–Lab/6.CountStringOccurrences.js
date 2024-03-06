function solve(text, serachedword){
    let array = text.split(' ');

    let sum = 0;

    array.forEach(element => {
        if(element === serachedword){
            sum++;
        }
    });

    console.log(sum);
}

solve('This is a word and it also is a sentence',
'is'
)