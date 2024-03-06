function solve(number, numbers){
    let newArray = numbers.splice(0, number)
        .reverse();
    
    let output = newArray.join(' ');
    console.log(output);
}

solve(3, [10, 20, 30, 40, 50]);