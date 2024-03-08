function solve(a, b, operator){
    let operation = (a,b,operator) => {
        switch (operator){
            case 'multiply':
                return a * b;
            case 'divide':
                return a / b;
            case 'add':
                return a + b;
            case 'subtract':
                return a - b;
        }
    }

    console.log(operation(a,b,operator));
}

solve(5,
    5,
    'multiply'
    );