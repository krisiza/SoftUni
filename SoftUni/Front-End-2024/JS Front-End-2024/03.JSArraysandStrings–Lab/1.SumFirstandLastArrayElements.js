function solve(numbers){
    let sum = 0;
    sum += numbers[0];
    sum += numbers[numbers.length-1];

    console.log(sum);
}

solve([20, 30, 40]);