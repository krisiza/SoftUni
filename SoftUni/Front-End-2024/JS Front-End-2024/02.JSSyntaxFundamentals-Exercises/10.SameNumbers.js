function solve(number){
    let text = number.toString();
    let sum = 0;

    let same = true;
    for(let i = 0; i < text.length; i++){

        sum += parseInt(text[i]);

        if(i < text.length-1){
            if(text[i] !== text[i+1]){
                same = false;           
            }
        }
    }

    console.log(same);
    console.log(sum);
}

solve(2222222);