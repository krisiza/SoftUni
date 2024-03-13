function solve(input){
    const person = {};

    for(let line of input){
        let array = line.split(':');
        person[array[0]] = array[1];
    }

    let oredered = Object.entries(person)
                .sort((a,b) => a[0].localeCompare(b[0]))
                .forEach(([name, address]) => console.log(`${name} -> ${address}`));

}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);