function solve(input){
    let movieList = [];

    for(let row of input){

        const addMovieCommand = 'addMovie';
        const directedByCommand = 'directedBy';
        const onDateCommand = 'onDate';

        if(row.includes(addMovieCommand)){
            const movie = {
                name: row.substring(addMovieCommand.length + 1)
            }; 
            movieList.push(movie);        
        }else if(row.includes(directedByCommand)){
            const [movieName, director] = row.split(` ${directedByCommand} `);
            const movie = movieList.find(movie => movie.name === movieName);

            if(movie){
                movie.director = director;
            }
            
        }else if(row.includes(onDateCommand)){
            let [movieName, date] = row.split(` ${onDateCommand} `);
            const movie = movieList.find(movie => movie.name === movieName);

            if(movie){
                movie.date = date;
            }
        }
    }

    movieList
    .filter(movie => movie.director && movie.date)
    .forEach(movie => console.log(JSON.stringify(movie)));
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