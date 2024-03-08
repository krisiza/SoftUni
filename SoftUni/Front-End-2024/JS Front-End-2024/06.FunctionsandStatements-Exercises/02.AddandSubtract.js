function solve(a,b,c){
    let sum = (a,b) => a + b;
    let substract = (a,b) => a - b;

    let result = substract(sum(a,b),c);
    console.log(result);
} 

solve(23,6,10);