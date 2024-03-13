function solve(input){
    let city = input;
    for(let line in city){
        console.log(`${line} -> ${city[line]}`);
    }
}
solve({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
});