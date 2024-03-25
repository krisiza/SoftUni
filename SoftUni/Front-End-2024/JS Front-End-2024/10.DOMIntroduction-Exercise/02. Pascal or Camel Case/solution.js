function solve() {
  const inputElement = document.getElementById('text');
  const caseElement = document.getElementById('naming-convention');
  const resultElement = document.getElementById('result');

  switch(caseElement.value){
    case 'Pascal Case':
      let arrayWordsPascalCase = inputElement.value.split(' ');
      let output = '';

      for(let word of arrayWordsPascalCase){
        word = word.charAt(0).toUpperCase() + word.toLowerCase().slice(1);;
        output += word;
      }

      resultElement.textContent = output;
      break;
    
    case 'Camel Case':
      let arrayWordsCamelCase = inputElement.value.split(' ');
      let outputCamelCase = '';

      for(let i = 0; i < arrayWordsCamelCase.length; i++){
        if(i == 0){
          outputCamelCase += arrayWordsCamelCase[i].toLowerCase();
        }
        else{
          outputCamelCase += arrayWordsCamelCase[i].charAt(0).toUpperCase() + arrayWordsCamelCase[i].toLowerCase().slice(1);;
        }
      }

      resultElement.textContent = outputCamelCase;
      break;
    
    default:
      resultElement.textContent = 'Error!';
  }
}