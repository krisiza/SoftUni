function solve(input){
    const phoneRecord = {};
    for(let record of input){
        let array = record.split(' ');
        phoneRecord[array[0]] = array[1];
    }

    for(let key in phoneRecord){
        console.log(`${key} -> ${phoneRecord[key]}`);
    }
}

solve(['George 0552554',
'Peter 087587',
'George 0453112',
'Bill 0845344']
);