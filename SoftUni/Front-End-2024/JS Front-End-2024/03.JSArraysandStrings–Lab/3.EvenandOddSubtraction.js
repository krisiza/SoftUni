function solve(numbers){
    let odd = numbers.filter(n => n % 2 !== 0);
    let even = numbers.filter(n => n % 2 === 0);

    let sumodd = odd.reduce((sum,n) => sum + n, 0);
    let sumeven = even.reduce((sum,n) => sum + n, 0)

    console.log(sumeven - sumodd);
}

solve([1,2,3,4,5,6]);