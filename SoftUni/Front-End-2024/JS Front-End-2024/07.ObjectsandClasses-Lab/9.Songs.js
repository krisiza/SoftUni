function solve(input){

    class Song{
        constructor(name, time){
            this.name = name;
            this.time = time;
        }
    }

    let numberOfSongs = input.shift();

    let songList = {};
    let allSongs = [];
    for(let i = 0; i < numberOfSongs; i++){
        const[type, songName, length] = input[i].split('_');

        if(!songList[type]){
            songList[type] = [];
        }

        allSongs.push(songName);

        songList[type].push(new Song(songName, length));
    }

    let favoriteList = input.pop();

    if(favoriteList == 'all'){
        for(let s of allSongs){
            console.log(s)
        }
    }else{
        for(let item of songList[favoriteList]){
        console.log(item.name);
        }
    }
}

solve([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'all']
    );