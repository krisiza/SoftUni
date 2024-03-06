function solve(array, step){
    let newarray = [];

    for(let i = 0; i < array.length; i += step){
        newarray.push(array[i]);
    }

   return newarray;
}

solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
);

