function solve(fruit, weightGr, pricePerKg){
    let weghtKg = weightGr / 1000;
    let totalPrice = weghtKg * pricePerKg;

    console.log(`I need \$${totalPrice.toFixed(2)} to buy ${weghtKg.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80)