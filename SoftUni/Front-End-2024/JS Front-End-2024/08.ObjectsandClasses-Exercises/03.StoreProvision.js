function solve(array1, array2){

    let addToObject = (obj, array) => {
        while(array.length > 0){
            let product = array.shift();
            let quantity = array.shift();
    
            if(!obj[product]){
                obj[product] = quantity;
            }else{
                obj[product] = Number(obj[product]) + Number(quantity);
            }
        }
    }

    let stock = {};

    addToObject(stock,array1);
    addToObject(stock, array2);

    for(let element in stock){
        console.log(`${element} -> ${stock[element]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
    );