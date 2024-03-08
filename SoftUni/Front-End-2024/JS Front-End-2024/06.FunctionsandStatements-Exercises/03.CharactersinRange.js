function solve(char1, char2){
    let smallestChar = (char1, char2) => char1 < char2 ? char1 : char2
    let biggerchar = (char1, char2) => char1 > char2 ? char1 : char2

    let start = smallestChar(char1, char2);
    let end = biggerchar(char1, char2);
    let result = [];

    for(let i= start.charCodeAt(0)+1; i < end.charCodeAt(0); i++){
        result.push(String.fromCharCode(i));
    }

    console.log(result.join(' '));
}

solve('a', 'd');