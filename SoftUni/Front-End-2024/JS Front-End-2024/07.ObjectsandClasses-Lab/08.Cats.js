
function solve(array){
    class Cat{
        constructor(catName, age){
            this.catName = catName;
            this.age = age;
        }
    
        meow(catName, age) {
            console.log(`${this.catName}, age ${this.age} says Meow`);
        }
    }

    for(let line of array){
        const[name, age] = line.split(' ');
        const cat = new Cat(name,age)
        cat.meow(name,age);
    }
}

solve(['Mellow 2', 'Tom 5']);