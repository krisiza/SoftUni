function solve(name, lastName, hairColor){
    const person = {
        name,
        lastName,
        hairColor
    }

    let jsonString = JSON.stringify(person);

    console.log(jsonString);
}

solve('George', 'Jones', 'Brown');