function solve(text, repeats){
    function repeatString(str, repeats){
        let result = '';

        for(let i = 0; i< repeats; i++){
            result += str;
        }

        return result;
    }

    console.log(repeatString(text, repeats));
}

solve("abc", 3);