function solve(input){

    for(let item of input){
        const[town, latitudeStr, longitudeStr] = item.split(' | ');

        let latitude = Number(latitudeStr).toFixed(2)
        let longitude = Number(longitudeStr).toFixed(2);
        let townObj = {
            town,
            latitude,
            longitude
        }

        console.log(townObj);
    }
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);