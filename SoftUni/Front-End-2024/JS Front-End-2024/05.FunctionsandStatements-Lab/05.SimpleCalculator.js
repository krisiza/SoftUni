function solve(a, b, operator) {
    var operations = {
        multiply: (a, b) => a * b,
        divide: (a, b) => a / b,
        add: (a, b) => a + b,
        subtract: (a, b) => a - b
    };

    console.log(operations[operator](a, b));
}

solve(5,
    5,
    'multiply'
    );