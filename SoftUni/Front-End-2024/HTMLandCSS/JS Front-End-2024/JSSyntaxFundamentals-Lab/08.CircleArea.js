function solve(input){
    let typeOfInput = typeof input;
    let result;

    switch (typeOfInput){
        case 'number':
            result = (input ** 2) * 3.14159265359;
            result = result.toFixed(2);
        break;
        default:
            result = `We can not calculate the circle area, because we receive a ${typeOfInput}.`;
        break;
    }

    console.log(result);
}
