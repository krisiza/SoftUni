function solve() {
   const btnAddProductElements = document.querySelectorAll('button.add-product');
   const checkoutElement = document.querySelector('button.checkout');
   const textareaElement = document.querySelector('textarea');

   let totalPrice = 0;
   let products = {};

   for(const button of btnAddProductElements){
      const product = button.parentElement.parentElement;

      button.addEventListener('click', () => {
         const title = product.querySelector('.product-title').textContent;
         let price = Number(product.querySelector('.product-line-price').textContent);
         totalPrice += price;
         products[title] = true;
         textareaElement.textContent += `Added ${title} for ${price.toFixed(2)} to the cart.\n`;
      });
   }

   checkoutElement.addEventListener('click', (event) => {
      Array.from(btnAddProductElements).forEach(button => button.setAttribute('disabled', 'true'));
      
      event.target.setAttribute('disabled', 'true');
      textareaElement.textContent += `You bought ${Object.keys(products).join(', ')} for ${totalPrice.toFixed(2)}.`;
   });
}