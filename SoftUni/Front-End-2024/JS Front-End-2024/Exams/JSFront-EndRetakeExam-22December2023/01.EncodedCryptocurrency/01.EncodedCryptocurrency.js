function solve(inputArray){
    let message = inputArray.shift();

    let command = inputArray.shift();

    while(command !== 'Buy'){
        
        if(command === 'TakeEven'){
            let newMessage = '';

            for(let i = 0; i < message.length; i++){
                if(i%2 === 0){
                    newMessage += message[i];
                }
            }

            message = newMessage;
            console.log(message);
        }

        if(command.includes('ChangeAll')){
            let commandInputs = command.split('?');

            let charToRevers = commandInputs[1];
            let newChar = commandInputs[2];

            while(message.includes(charToRevers)){
                message = message.replace(charToRevers, newChar);
            }

            console.log(message);
        }

        if(command.includes('Reverse')){
            let commandInputs = command.split('?');

            let stringToReverse = commandInputs[1];

            if(message.includes(stringToReverse)){
                message = message.replace(stringToReverse, '');
                let arrayFromString = stringToReverse.split('');
                let reverseArray = arrayFromString.reverse();
                let reversedString = reverseArray.join('');
                message += reversedString;
                console.log(message);
            }else{
                console.log('error');
            }
        }

        command = inputArray.shift();
    }

    console.log(`The cryptocurrency is: ${message}`);
}

solve((["z2tdsfndoctsB6z7tjc8ojzdngzhtjsyVjek!snfzsafhscs",

"TakeEven",

"Reverse?!nzahc",

"ChangeAll?m?g",

"Reverse?adshk",

"ChangeAll?z?i",

"Buy"]));