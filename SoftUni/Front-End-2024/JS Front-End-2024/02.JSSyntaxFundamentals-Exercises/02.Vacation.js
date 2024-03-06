function solve(groupOfPeople, typeOfGroup, dayOfTheWeek){
    let price;
    let sum;

    switch(typeOfGroup){
        case 'Students':
            if(dayOfTheWeek === 'Friday'){
                price = 8.45;
            }else if(dayOfTheWeek === 'Saturday'){
                price = 9.8;
            }else{
                price = 10.46;
            }

            sum = price * groupOfPeople;
            if(groupOfPeople >= 30){
                sum *= 0.85;
            }

        break;
        case 'Business':
            if(dayOfTheWeek === 'Friday'){
                price = 10.9;
            }else if(dayOfTheWeek === 'Saturday'){
                price = 15.6;
            }else{
                price = 16;
            }

            sum = price * groupOfPeople;
            if(groupOfPeople >= 100){
                sum -= price * 10;
            }

        break;
        case 'Regular':
            if(dayOfTheWeek === 'Friday'){
                price = 15;
            }else if(dayOfTheWeek === 'Saturday'){
                price = 20;
            }else{
                price = 22.5;
            }

            sum = price * groupOfPeople;
            if(groupOfPeople >= 10 && groupOfPeople <= 20){
                sum *= 0.95;
            }

        break;
    }

    console.log(`Total price: ${sum.toFixed(2)}`);
}

solve(40,
    "Regular",
    "Saturday"
    )