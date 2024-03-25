function solve() {

  const textAreaElements = [...document.getElementsByTagName('textarea')];
  const buttonElements = [...document.getElementsByTagName('button')];
  
  buttonElements[0].addEventListener('click', function(){
    
    console.log(textAreaElements[0].value);
  })
}