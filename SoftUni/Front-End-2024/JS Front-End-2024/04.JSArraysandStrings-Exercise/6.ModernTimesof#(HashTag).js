function solve(text){
    const pattern = /#([a-zA-Z]+)/g;
    const matches = text.matchAll(pattern);

    for(const match of matches){
        console.log(match[1]);
    }
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');