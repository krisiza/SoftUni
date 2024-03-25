function search() {
   const townsElement = document.getElementById('towns');
   const townToSearchElemtn = document.getElementById('searchText');
   const resultElement = document.getElementById('result');
   const townsList = townsElement.children;
   
   resultElement.textContent = '';

   for(let town of Array.from(townsList)){

      town.style.fontWeight = 'normal';
      town.style.textDecoration = 'none';
   }

   let matches = 0;

   for(let town of  Array.from(townsList)){
      const regex = new RegExp(`${townToSearchElemtn.value}[a-z]*`, 'gm');

      if(regex.test(town.textContent)){
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         matches++;
      }
   }

   resultElement.textContent = `${matches} matches found`;
}

