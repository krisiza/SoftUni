function solve(input){
    const workers = Number(input.shift());

    const barista = {};
    for(let i = 0; i < workers; i++){
        const [name, shift, drinks] = input.shift().split(' ');

        barista[name] = {
            shift,
            drinks: drinks.split(',')
        };
    }

    let arg = input.shift();
    while (arg !== 'Closed') {
        const [command, baristaName, shift, drink] = arg.split(' / ');

        switch(command){
            case 'Prepare':
                if(barista[baristaName].shift === shift && barista[baristaName].drinks.includes(drink)){
                    console.log(`${baristaName} has prepared a ${drink} for you!`);
                }else{
                    console.log(`${baristaName} is not available to prepare a ${drink}.`);
                }
                break;
            case 'Change Shift':
                barista[baristaName].shift = shift;
                console.log(`${baristaName} has updated his shift to: ${shift}`);
                break;   
                
            case 'Learn':
                if(barista[baristaName].drinks.includes(shift)){
                    console.log(`${baristaName} knows how to make ${shift}.`);
                }else{
                    barista[baristaName].drinks.push(shift);
                    console.log(`${baristaName} has learned a new coffee type: ${shift}.`);
                }
                break; 
        }

        arg = input.shift();
    }

    Object.keys(barista).forEach( b => {
        console.log(`Barista: ${b}, Shift: ${barista[b].shift}, Drinks: ${barista[b].drinks.join(', ')}`);
    });
}

solve([

    '3',
    
    'Alice day Espresso,Cappuccino',
    
    'Bob nigth Latte,Mocha',
    
    'Carol day Americano,Mocha',
    
    'Prepare / Alice / day / Espresso',
    
    'Change Shift / Bob / night',
    
    'Learn / Carol / Latte',
    
    'Learn / Bob / Latte',
    
    'Prepare / Bob / night / Latte',
    
    'Closed'])