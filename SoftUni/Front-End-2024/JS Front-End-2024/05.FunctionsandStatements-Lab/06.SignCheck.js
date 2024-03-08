function solve(a,b,c){
    let multiply = (a,b) => a * b;

    if(multiply(a, multiply(b,c)) < 0){
        console.log('Negative');
    }else{
        console.log('Positive');
    }
}

solve(5,12,-15)