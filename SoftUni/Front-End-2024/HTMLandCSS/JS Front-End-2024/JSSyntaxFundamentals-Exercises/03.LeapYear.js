function solve(year){
    let resultWith4 = year / 4;
    let resultWith100 = year / 100;
    let resultWith400 = year / 400;

    if((resultWith4 % 1 === 0 && resultWith100 % 1 !== 0) || resultWith400 % 1 === 0){
        console.log('yes');
    }else{
        console.log('no');
    }

}

solve(4);