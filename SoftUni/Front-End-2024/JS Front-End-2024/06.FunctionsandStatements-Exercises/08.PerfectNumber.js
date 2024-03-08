function solve(number){
    
    let numberIsBiggerThanZero = number => number > 0;

    let equalToAllPositiveDivisors = number => {
        let sum = 0;

        for(let i = 1; i < number; i++){
            if(number % i === 0){
                sum += i;
            }
        }

        if(number === sum)
            return true;
        else
            return false;
    }

    if(numberIsBiggerThanZero(number) && equalToAllPositiveDivisors(number)){
        console.log('We have a perfect number!');
    }else{
        console.log('It\'s not so perfect.');
    }
}

solve(1236498);