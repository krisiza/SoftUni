function solve(number){
    let sum = 0;

    let text=number.toString();

    for(let i = 0; i < text.length; i++){
        sum += parseInt(text[i]);
    }

    console.log(sum);
}

solve(245678);