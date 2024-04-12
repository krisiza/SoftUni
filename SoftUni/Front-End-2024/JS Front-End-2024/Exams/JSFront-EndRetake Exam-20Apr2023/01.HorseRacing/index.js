function solve(input){
    let horses = input.shift().split('|');

    let commandLine = input.shift();

    while(commandLine !== 'Finish'){
        const[command, ...args] = commandLine.split(' ');

        switch(command){
            case 'Retake':
                let overTakingHorseIndex = horses.indexOf(args[0]);
                let overTakedHorseIndex = horses.indexOf(args[1]);

                if(overTakingHorseIndex < overTakedHorseIndex){
                    const temp = horses[overTakedHorseIndex];
                    horses[overTakedHorseIndex] = horses[overTakingHorseIndex];
                    horses[overTakingHorseIndex] = temp;

                    console.log(`${args[0]} retakes ${args[1]}.`);
                }
                break;
            case 'Trouble':
                let horseIndex = horses.indexOf(args[0]);

                if(horseIndex > 0){
                    const temp = horses[horseIndex];
                    horses[horseIndex] = horses[horseIndex - 1];
                    horses[horseIndex - 1] = temp;

                    console.log(`Trouble for ${args[0]} - drops one position.`);
                }
                break;
            case 'Rage':
                let horseIndexRage = horses.indexOf(args[0]);

                if(horseIndexRage === horses.length-1){
                    console.log(`${args[0]} rages 2 positions ahead.`);
                    break;
                }

                
                if (horseIndexRage + 1 === horses.length-1){
                    const temp = horses[horses.length-1];
                    horses[horses.length-1] = horses[horseIndexRage];
                    horses[horseIndexRage] = temp;

                    console.log(`${args[0]} rages 2 positions ahead.`);
                    break;
                }

                let newHorsePosition = horseIndexRage + 2;

                if(newHorsePosition > horses.length -1){
                    newHorsePosition =  horses.length -1;
                }


                for(let i = 0; i < 2; i++){
                    temp = horses[horseIndexRage + i];
                    horses[horseIndexRage + i] = horses[horseIndexRage + i + 1];
                    horses[horseIndexRage + i + 1] = temp;
                }
                console.log(`${args[0]} rages 2 positions ahead.`);
                

                break;
            case 'Miracle':
                for(let i = 0; i < horses.length-1; i++){
                    temp = horses[i];
                    horses[i] = horses[i + 1];
                    horses[i + 1] = temp;
                }

                console.log(`What a miracle - ${horses[horses.length-1]} becomes first.`)
                break;
        }

        commandLine = input.shift();
    }
    console.log(horses.join('->'));
    console.log(`The winner is: ${horses[horses.length-1]}`)
}

solve((['Onyx|Fiona|Suger|Domino',

'Trouble Onyx',

'Retake Onyx Sugar',

'Rage Domino',

'Miracle',

'Finish']));