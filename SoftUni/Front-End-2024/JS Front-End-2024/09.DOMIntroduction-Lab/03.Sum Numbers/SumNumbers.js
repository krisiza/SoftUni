function calc() {
   const firstNumberElement = document.getElementById('num1');
   const secondNumberElement = document.getElementById('num2');
   const sumElement = document.getElementById('sum');

   sumElement.value = Number(firstNumberElement.value) + Number(secondNumberElement.value);
}
