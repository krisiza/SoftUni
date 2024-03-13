function solve(input){

    const meeting = {};
    for(let item of input){
        let array = item.split(' ');

        if(meeting[array[0]]){
            console.log(`Conflict on ${array[0]}!`);
        }else{
            meeting[array[0]] = array[1];
            console.log(`Scheduled for ${array[0]}`);
        }
    }

    for(const line in meeting){
        console.log(`${line} -> ${meeting[line]}`);
    }
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);