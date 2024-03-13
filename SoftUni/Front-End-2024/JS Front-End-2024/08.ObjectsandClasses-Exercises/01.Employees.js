function solve(array){

    let empoyee = {};

    for(let item of array){
        empoyee[item] = item.length;
    }

    for(let element in empoyee){
        console.log(`Name: ${element} -- Personal Number: ${empoyee[element]}`);
    }
}

solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );