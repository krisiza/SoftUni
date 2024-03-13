function solve(input){
    const person = JSON.parse(input);

    for(let line in person){
        console.log(`${line}: ${person[line]}`);
    }
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');