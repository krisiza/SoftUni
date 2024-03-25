function create(words) {
   const divElement = document.getElementById('content');

   for(const word of words){
      const newDivElement = document.createElement('div');
      const paragraphElement = document.createElement('p');
      paragraphElement.textContent = word;
      paragraphElement.style.display = 'none';
      newDivElement.appendChild(paragraphElement);
      newDivElement.addEventListener('click', function (event){
         paragraphElement.style.display = 'block'
      });

      divElement.appendChild(newDivElement);
   }
}