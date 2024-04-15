window.addEventListener("load", solve);

function solve() {
    const nameInputElement = document.getElementById(`name`);
    const phoneNumberInputElement = document.getElementById(`phone`);
    const categoryInputElement = document.getElementById(`category`);
    const addButtonElement = document.getElementById(`add-btn`);
    const checkListElement = document.getElementById(`check-list`);
    const contactListElement = document.getElementById(`contact-list`);

    addButtonElement.addEventListener(`click`, () => {
      if(nameInputElement.value === `` ||
      phoneNumberInputElement.value === `` ||
      categoryInputElement.selectedIndex === 0){
        return;
      }

      const editButtonElement = document.createElement('button');
      editButtonElement.classList.add('edit-btn');
      editButtonElement.addEventListener('click', edit);

      const saveButtonElement = document.createElement('button');
      saveButtonElement.classList.add('save-btn');
      saveButtonElement.addEventListener('click', save);

      const buttonsDivElement = document.createElement('div');
      buttonsDivElement.classList.add(`buttons`);
      buttonsDivElement.appendChild(editButtonElement);
      buttonsDivElement.appendChild(saveButtonElement);

      const namePElement = document.createElement('p');
      namePElement.textContent = `name:${nameInputElement.value}`;
      let name = nameInputElement.value;

      const phonePElement = document.createElement('p');
      phonePElement.textContent = `phone:${phoneNumberInputElement.value}`;
      let phone = phoneNumberInputElement.value;

      const categoryPElement = document.createElement('p');
      categoryPElement.textContent = `category:${categoryInputElement.value}`;
      let categoryIndex = categoryInputElement.selectedIndex;

      const articleElement = document.createElement('article');
      articleElement.appendChild(namePElement);
      articleElement.appendChild(phonePElement);
      articleElement.appendChild(categoryPElement);

      const liElement = document.createElement('li');
      liElement.appendChild(articleElement);
      liElement.appendChild(buttonsDivElement);

      checkListElement.appendChild(liElement);

      nameInputElement.value = '';
      phoneNumberInputElement.value = '';
      categoryInputElement.value = '';

      function edit(){
        nameInputElement.value = name;
        phoneNumberInputElement.value = phone;
        categoryInputElement.selectedIndex = categoryIndex;

        liElement.remove();
      }

      function save(){
        liElement.remove();
        buttonsDivElement.remove();

        const deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('del-btn');
        deleteButtonElement.addEventListener('click', () => {
          liElement.remove();
        });

        liElement.appendChild(deleteButtonElement);
        contactListElement.appendChild(liElement);
      }
    })
  }
  