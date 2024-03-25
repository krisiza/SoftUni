function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const searchedElemet = document.getElementById('searchField');
      const rowsTable = document.querySelectorAll('table tbody tr');


      for(let row of Array.from(rowsTable)){
         row.classList.remove('select'); 
      }

      const regex = new RegExp(`${searchedElemet.value}[a-z]*`, 'gm');

      for(let row of Array.from(rowsTable)){
         for(let data of Array.from(row.children)){
            
            if(regex.test(data.textContent)){
               row.classList.add('select');
            }
         }
      }

      searchedElemet.value = '';
   }
}