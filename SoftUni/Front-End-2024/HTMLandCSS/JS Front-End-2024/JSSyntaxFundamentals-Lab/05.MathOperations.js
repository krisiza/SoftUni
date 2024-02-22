function solve(num1, num2, input){
    let result;
    switch(input){
        case '+':
            result = num1 + num2;
        break;
        case '-':
            result = num1 - num2;
        break;
        case '*':
            result = num1 * num2;
        break;
        case '/':
            result = num1 / num2;
        break;
        case '%':
            result = num1 % num2;
        break;
        case '**':
            result = num1 ** num2;
        break;
    }

    console.log(result);
}