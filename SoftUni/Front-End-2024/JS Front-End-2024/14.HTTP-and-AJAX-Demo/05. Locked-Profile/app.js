async function lockedProfile() {
    const urlProfiles = 'http://localhost:3030/jsonstore/advanced/profiles';

    const profileElement = document.querySelector('.profile');
    const mainElement = document.querySelector('#main');
    profileElement.remove();

    const response = await fetch(urlProfiles);
    const profiles = await response.json();

    Object.values(profiles)
                    .forEach(profil => {
       
        const divProfileElement = document.createElement('div');
        divProfileElement.classList.add('profile');

        const imgElement = document.createElement('img');
        imgElement.src = "./iconProfile2.png";
        imgElement.classList.add('userIcon');
        divProfileElement.appendChild(imgElement);

        const labelLockElement = document.createElement('label');
        labelLockElement.textContent = 'Lock';
        divProfileElement.appendChild(labelLockElement);

        const inputRadioLockElement = document.createElement('input');
        inputRadioLockElement.type = 'radio';
        inputRadioLockElement.name = `${profil.username}Locked`;
        inputRadioLockElement.value = 'lock';
        inputRadioLockElement.checked = true;
        divProfileElement.appendChild(inputRadioLockElement);

        
        const labelUnLockElement = document.createElement('label');
        labelUnLockElement.textContent = 'Unlock';
        divProfileElement.appendChild(labelUnLockElement);

        const inputRadioUnockElement = document.createElement('input');
        inputRadioUnockElement.type = 'radio';
        inputRadioUnockElement.name = `${profil.username}Locked`;
        inputRadioUnockElement.value = 'unlock';
        divProfileElement.appendChild(inputRadioUnockElement);

        const brElement = document.createElement('br');
        divProfileElement.appendChild(brElement);

        const hrElement = document.createElement('hr');
        divProfileElement.appendChild(hrElement);

        const labelUsernameElement = document.createElement('label');
        labelUsernameElement.textContent = 'Username';
        divProfileElement.appendChild(labelUsernameElement);

        const inputUsernameElement = document.createElement('input');
        inputUsernameElement.type = 'text';
        inputUsernameElement.name = `user1Username`;
        inputUsernameElement.value = profil.username;
        inputUsernameElement.disabled = true;
        inputUsernameElement.readOnly = true;
        divProfileElement.appendChild(inputUsernameElement);

        const divHiddenFieldsElement = document.createElement('div');
        divHiddenFieldsElement.id = `${profil.username}HiddenFields`;

        const hr2Element = document.createElement('hr');
        divHiddenFieldsElement.appendChild(hr2Element);

        const labelEmailElement = document.createElement('label');
        labelEmailElement.textContent = 'Email';
        divHiddenFieldsElement.appendChild(labelEmailElement);

        const inputEmailElement = document.createElement('input');
        inputEmailElement.type = 'email';
        inputEmailElement.name = `${profil.username}Email`;
        inputEmailElement.value = profil.email;
        inputEmailElement.disabled = true;
        inputEmailElement.readOnly = true;
        divHiddenFieldsElement.appendChild(inputEmailElement);

        const labelAgeElement = document.createElement('label');
        labelAgeElement.textContent = 'Age';
        divHiddenFieldsElement.appendChild(labelAgeElement);

        const inputAgeElement = document.createElement('input');
        inputAgeElement.type = 'email';
        inputAgeElement.name = `${profil.username}Age`;
        inputAgeElement.value = profil.age;
        inputAgeElement.disabled = true;
        inputAgeElement.readOnly = true;
        divHiddenFieldsElement.appendChild(inputAgeElement);

        divHiddenFieldsElement.style.display = 'none';
        divProfileElement.appendChild(divHiddenFieldsElement);

        const showMoreButtonElement = document.createElement('button');
        showMoreButtonElement.textContent = 'Show more';

        showMoreButtonElement.addEventListener('click', (e) => {

            if(e.currentTarget.parentElement.querySelector('input[type=radio]:first-of-type').checked === false){
                e.currentTarget.previousSibling.style.display = 'block';
                showMoreButtonElement.remove();

                const hideItButtonElement = document.createElement('button');
                hideItButtonElement.textContent = 'Hide it';
                
                hideItButtonElement.addEventListener('click', (event) => {
                    if(event.currentTarget.parentElement.querySelector('input[type=radio]:first-of-type').checked === false){
                        event.currentTarget.previousSibling.style.display = 'none';
                        hideItButtonElement.remove();

                        divProfileElement.appendChild(showMoreButtonElement);
                    }
                })

                divProfileElement.appendChild(hideItButtonElement);
            }

        })

        divProfileElement.appendChild(showMoreButtonElement);

        mainElement.appendChild(divProfileElement);
    });
}