function solve(n,m){
    let sum = 0;
    let combination = '';

    for(let i = n; i <= m; i++){
        combination += i + ' ';
        sum = sum + i;
    }
    console.log(combination);
    console.log('Sum: ' + sum);
}

solve(5,10);