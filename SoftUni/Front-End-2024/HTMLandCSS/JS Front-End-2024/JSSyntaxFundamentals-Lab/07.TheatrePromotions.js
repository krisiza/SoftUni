function solve(typeOfDay, age){

    let ticketPrice;

    if(age >= 0 && age <= 18){
        if(typeOfDay === 'Weekday'){
            ticketPrice = 12;
        }else if(typeOfDay === 'Weekend'){
            ticketPrice = 15;
        }else{
            ticketPrice = 5;
        }
    }else if(age > 18 && age <= 64){
        if(typeOfDay === 'Weekday'){
            ticketPrice = 18;
        }else if(typeOfDay === 'Weekend'){
            ticketPrice = 20;
        }else{
            ticketPrice = 12;
        }
    }else if(age > 64 && age <= 122){
        if(typeOfDay === 'Weekday'){
            ticketPrice = 12;
        }else if(typeOfDay === 'Weekend'){
            ticketPrice = 15;
        }else{
            ticketPrice = 10;
        }
    }
    else{
        console.log('Error!');
    }

    if(ticketPrice){
        console.log(ticketPrice + '$');
    }
}
