function solve(input){
    let number = Number(input.shift());

    const hero = {};
    for(let i = 0; i < number; i++){
        const [name, hp, bullets] = input.shift().split(` `);

        hero[name] = {
            hp: Number(hp),
            bullets: Number(bullets)
        }     
    }

    let commandLine = input.shift();

    while(commandLine != `Ride Off Into Sunset`){
        const[command, name, ...args] = commandLine.split(` - `);

        switch(command){
            case `FireShot`:
                let target = args[0];
                if(hero[name].bullets > 0){
                    hero[name].bullets--;
                    console.log(`${name} has successfully hit ${target} and now has ${hero[name].bullets} bullets!`);
                }else{
                    console.log(`${name} doesn't have enough bullets to shoot at ${target}!`);
                }
                break;
            case `TakeHit`:
                let damege = Number(args[0]);
                let attacker = args[1];

                hero[name].hp -= damege;

                if(hero[name].hp > 0){
                    console.log(`${name} took a hit for ${damege} HP from ${attacker} and now has ${hero[name].hp} HP!`);
                }else{
                    delete hero[name];
                    console.log(`${name} was gunned down by ${attacker}!`);
                }
                break;
            case `Reload`:
                if(hero[name].bullets < 6){
                    console.log(`${name} reloaded ${6 - hero[name].bullets} bullets!`);
                    hero[name].bullets = 6;
                }else{
                    console.log(`${name}'s pistol is fully loaded!`);
                }
                break;
            case `PatchUp`:
                let amount = Number(args[0]);
                if(hero[name].hp === 100){
                    console.log(`${name} is in full health!`);
                }else{
                    let oldHp = hero[name].hp;
                    hero[name].hp += amount;
    
                    if(hero[name].hp > 100){
                        hero[name].hp = 100;
                    }
                    console.log(`${name} patched up and recovered ${hero[name].hp - oldHp} HP!`);
                }
                break;
        }
        commandLine = input.shift();
    }

    Object.keys(hero).forEach( name => {
        console.log(`${name}\n HP: ${hero[name].hp}\n Bullets: ${hero[name].bullets}`);
    });
    
}

solve((["2",
"Jesse 100 4",
"Walt 100 5",
"FireShot - Jesse - Bandit",
 "TakeHit - Walt - 30 - Bandit",
 "PatchUp - Walt - 20" ,
 "Reload - Jesse",
 "Ride Off Into Sunset"])

);