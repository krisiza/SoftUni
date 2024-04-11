function solve(input){
    const astronautCount = Number(input.shift());

    const austronaut = {};

    for(let i = 0; i < astronautCount; i++)
    {
        const[name, oxygen, energy] = input.shift().split(' ');

        austronaut[name] = {
            oxygen: Number(oxygen),
            energy: Number(energy)
        }
    }

    let commandLine = input.shift();

    while (commandLine !== 'End'){
        const [command, name, arg] = commandLine.split(' - ');

        switch (command){
            case 'Explore':
                let neededEnergy = Number(arg);

                if(austronaut[name].energy >= neededEnergy){
                    austronaut[name].energy -= neededEnergy;
                    console.log(`${name} has successfully explored a new area and now has ${austronaut[name].energy} energy!`)
                }else{
                    console.log(`${name} does not have enough energy to explore!`);
                }
                break;

            case 'Refuel':
                let amount = Number(arg);
                let lastEnergy =  austronaut[name].energy;
                austronaut[name].energy += amount;

                if(austronaut[name].energy > 200){
                    austronaut[name].energy = 200;
                }

                console.log(`${name} refueled their energy by ${austronaut[name].energy - lastEnergy}!`);
                break;

            case 'Breathe':
                let amountOxygen = Number(arg);
                let lastOxygen =  austronaut[name].oxygen;
                austronaut[name].oxygen += amountOxygen;

                if(austronaut[name].oxygen > 100){
                    austronaut[name].oxygen = 100;
                }
                console.log(`${name} took a breath and recovered ${austronaut[name].oxygen - lastOxygen} oxygen!`)
                break;
        }

        commandLine = input.shift();
    }

    Object.keys(austronaut).forEach((a) => {console.log(`Astronaut: ${a}, Oxygen: ${austronaut[a].oxygen}, Energy: ${austronaut[a].energy}`)});
}

solve([ '3',

    'John 50 120',

    'Kate 80 180',

    'Rob 70 150',

    'Explore - John - 50',

    'Refuel - Kate - 30',

    'Breathe - Rob - 20',

    'End']);