function solve(input){

    class Movie{
        constructor(name){
            const pattern = new RegExp(',', 'g');
            name = name.replace(pattern, ' ');
            this.name = name;
        }

        name = null
        date = null;
        director = null;
    }

    let addMovie = (movieName, objList) =>{
        if(!objList.find(x => x.name === movieName)){
            objList.push(new Movie(movieName))
        }
    }

    let addDirector = (movieName, directorName, objList) => {
        var foundMovie =objList.find(x => x.name === movieName);
        if(foundMovie){
            foundMovie.director = directorName;
        }
    }

    let onDate = (movieName, dateList, objList) => {
        var foundMovie = objList.find(x => x.name === movieName);
        if(foundMovie){
            foundMovie.date = dateList;
        }
    }

    let movieList = [];
    const pattern = new RegExp(',', 'g');

    for(let element of input){
        let line = element.split(' ');

        if(line.find( x => x ==='addMovie')){
            const[comand, ...rest] = element.split(' ');
            addMovie(rest.toString(), movieList);
        }else if(line.find( x => x ==='directedBy')){
            let listdirector = line.toString().split('directedBy');
            let m = listdirector[0].replace(pattern, ' ')
                                    .trim();
            let d = listdirector[1].replace(pattern, ' ')
                            .trim();
            addDirector(m, d, movieList);
        }else if(line.find( x => x ==='onDate')){
            let listdate = line.toString().split('onDate');
            let m = listdate[0].replace(pattern, ' ')
                                .trim();
            let d = listdate[1].replace(pattern, ' ')
                            .trim();
            onDate(m, d, movieList);
        }
    }

    console.log(JSON.stringify(movieList).replace('[', '').replace(']', ''));
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]
    );