function solve(a,b){

    let factorial = number => {
        let result = 1;

        for(let i = 1; i <= number; i++){
            result *= i;
        }

        return result;
    }

    let numberFac = factorial(a);
    let number2Fac = factorial(b);

    console.log((numberFac / number2Fac).toFixed(2));
}

solve(6,2);