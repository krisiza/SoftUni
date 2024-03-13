function solve(array){

    for(let i = 0; i < array.length; i++){
        let word = array[i].toString();
        let wordArray = word.split('');

        let palindrom = true
        while(wordArray.length > 1){
            let char1 = wordArray.shift();
            let char2 = wordArray.pop();

            if(char1 !== char2){
                palindrom = false;
                break;
            }

        }
        console.log(palindrom);     
    }
}

solve([32,2,232,1010, 1111]);