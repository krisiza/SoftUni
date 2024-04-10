function attachEvents() {
    const url = `http://localhost:3030/jsonstore/messenger`;

    const submitButtonElement = document.querySelector('#submit')
    const refreshButtonElement = document.querySelector('#refresh');
    const inputAuthorElement = document.querySelector('input[name=author]');
    const inputContentElement = document.querySelector('input[name=content]');
    const textAreaElement = document.querySelector('#messages');


    submitButtonElement.addEventListener('click', () => {

        fetch(url, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                author: inputAuthorElement.value,
                content: inputContentElement.value
            })
        })
            .then((res) => res.json())
            .then(() => {
                inputAuthorElement.value = '';
                inputContentElement.value = '';
            });

    })

    refreshButtonElement.addEventListener('click', () => {
        textAreaElement.value = '';

        fetch(url)
            .then(res => res.json())
            .then(data => {
                for(let i = 0; i < Object.values(data).length; i++){
                    if(i < Object.values(data).length - 1){
                        textAreaElement.value += `${Object.values(data)[i].author}: ${Object.values(data)[i].content}\n`;
                    }else{
                        textAreaElement.value += `${Object.values(data)[i].author}: ${Object.values(data)[i].content}`;
                    }
                }
            })
    })
}

attachEvents();