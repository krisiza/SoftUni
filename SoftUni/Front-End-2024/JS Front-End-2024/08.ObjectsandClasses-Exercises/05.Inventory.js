function solve(array){
    let heroList = [];
    let hero = {};
    for(let item of array){
        const[name, level,items] = item.split(' / ');
        hero ={
            name,
            level,
            items
        }

        heroList.push(hero);
    }

    heroList = heroList.sort((a, b) => a.level - b.level);

    for(let item of heroList){
        console.log(`Hero: ${item.name}`);
        console.log(`level => ${item.level}`);
        console.log(`items => ${item.items}`);
    }
}

solve([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
    )