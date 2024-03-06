function solve(numbers){
    
    let sortednumbers = numbers.sort((a,b) => a - b);
    let newarray = [];
    
    while(numbers.length > 0){
        newarray.push(sortednumbers.shift());

        if(numbers.length > 0)
        {
            newarray.push(sortednumbers.pop());
        }
    }
    

    return newarray;
}
