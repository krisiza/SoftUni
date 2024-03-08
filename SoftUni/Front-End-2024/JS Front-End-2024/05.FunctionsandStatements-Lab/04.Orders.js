function solve(product, price){

    function productPrice() {
        switch (product){
            case 'coffee':
            return 1.5;
            case 'water':
            return 1;
            case 'coke':
            return 1.4;
            case 'snacks':
            return 2;

        }
    }

    console.log((productPrice() * price).toFixed(2));
}

solve('water', 5);