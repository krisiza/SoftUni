function solve(number){
    let makearray = (number) => number.toString().split('');

    let array = makearray(number);

    let sumOdd = (array) => array
        .filter(x => x % 2 !==  0)
        .reduce((accumulator, currentValue) => accumulator + parseInt(currentValue), 0)

    let sumEven = (array) => array
        .filter(x => x % 2 ===  0)
        .reduce((accumulator, currentValue) => accumulator + parseInt(currentValue), 0)

    console.log(`Odd sum = ${sumOdd(array)}, Even sum = ${sumEven(array)}`);
}

solve(1000435);