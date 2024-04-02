function solve() {

  const textAreaInputElement = document.querySelector('#exercise textarea:first-of-type');
  const textArearOutputElement = document.querySelector('#exercise textarea:last-of-type');
  const generateButtonElement = document.querySelector('#exercise button:first-of-type');
  const buyButtonElement = document.querySelector('#exercise button:last-of-type');
  const furnitureTbodyElement = document.querySelector('.table tbody');


  generateButtonElement.addEventListener('click', () => {
    const furnitures = JSON.parse(textAreaInputElement.value);

    for(const furnirure of furnitures){ 
      const imageElement = document.createElement('img');
      imageElement.src = furnirure.img;

      const imageTdElement = document.createElement('td');
      imageTdElement.appendChild(imageElement);

      const namePElement = document.createElement('p');
      namePElement.textContent = furnirure.name;
      const nameTdElement = document.createElement('td');
      nameTdElement.appendChild(namePElement);

      const pricePElement = document.createElement('p');
      pricePElement.textContent = furnirure.price;
      const priceeTdElement = document.createElement('td');
      priceeTdElement.appendChild(pricePElement);

      const decorPElement = document.createElement('p');
      decorPElement.textContent = furnirure.decFactor;
      const decorTdElement = document.createElement('td');
      decorTdElement.appendChild(decorPElement);

      const markElement = document.createElement('input');
      markElement.setAttribute('type', 'checkbox');
      const markTdElement = document.createElement('td');
      markTdElement.appendChild(markElement);

      const furnitureTrElement = document.createElement('tr');
      furnitureTrElement.appendChild(imageTdElement);
      furnitureTrElement.appendChild(nameTdElement);
      furnitureTrElement.appendChild(priceeTdElement);
      furnitureTrElement.appendChild(decorTdElement);
      furnitureTrElement.appendChild(markTdElement);

      furnitureTbodyElement.appendChild(furnitureTrElement);
    }
  })

  buyButtonElement.addEventListener('click', (e) => {

    let totalPrice = 0;
    let totalDecorationfactor = 0;
    let markedChilderen = 0;
    let names = [];

    Array.from(furnitureTbodyElement.children)
    .forEach(furnitreTrElement => {
      const markInputElement = furnitreTrElement.querySelector('input[type=checkbox]')

      if(!markInputElement.checked){
        return;
      }

      const name = furnitreTrElement.children[1].textContent;
      const price = Number(furnitreTrElement.children[2].textContent);
      const decFactor = Number(furnitreTrElement.children[3].textContent);

      names.push(name);
      totalPrice += price;
      totalDecorationfactor += decFactor;
      markedChilderen++;
    })

    const averageDecorationFactor = totalDecorationfactor / markedChilderen;

    textArearOutputElement.textContent += `Bought furniture: ${names.join(', ')}\n`;
    textArearOutputElement.textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
    textArearOutputElement.textContent += `Average decoration factor: ${averageDecorationFactor}`;
  })
}