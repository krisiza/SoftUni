window.addEventListener("load", solve);

function solve() {
    const titleInputElement = document.getElementById('task-title');
    const categoryInputElement = document.getElementById('task-category');
    const contentInputElement = document.getElementById('task-content');
    const publischButtonElement = document.getElementById('publish-btn');
    const reviewListElement = document.getElementById('review-list');
    const publischedListElement = document.getElementById('published-list');

    publischButtonElement.addEventListener('click', () => {
        if(titleInputElement.value === ''||
        categoryInputElement.value === '' ||
        contentInputElement.value === ''){
            return;
        }

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('action-btn', 'edit');
        editButtonElement.textContent = 'Edit';
        editButtonElement.addEventListener('click', edit);

        const postButtonElement = document.createElement('button');
        postButtonElement.classList.add('action-btn', 'post');
        postButtonElement.textContent = 'Post';
        postButtonElement.addEventListener('click', post);

        const titleH4Element = document.createElement('h4');
        titleH4Element.textContent = titleInputElement.value;
        let title = titleInputElement.value;

        const categoryPElement = document.createElement('p');
        categoryPElement.textContent = `Category: ${categoryInputElement.value}`;
        let category = categoryInputElement.value;

        const contentPElement = document.createElement('p');
        contentPElement.textContent = `Content: ${contentInputElement.value}`;
        let content = contentInputElement.value;

        const articleElement = document.createElement('article');
        articleElement.appendChild(titleH4Element);
        articleElement.appendChild(categoryPElement);
        articleElement.appendChild(contentPElement);

        const rpostLiElement = document.createElement('li');
        rpostLiElement.classList.add('rpost');
        rpostLiElement.appendChild(articleElement);
        rpostLiElement.appendChild(editButtonElement);
        rpostLiElement.appendChild(postButtonElement);

        reviewListElement.appendChild(rpostLiElement);

        titleInputElement.value = '';
        categoryInputElement.value = '';
        contentInputElement.value = '';

        function edit(){
            titleInputElement.value = title;
            categoryInputElement.value = category;
            contentInputElement.value = content;

            rpostLiElement.remove();
        }

        function post(){
            rpostLiElement.remove();
            publischedListElement.appendChild(rpostLiElement);
            editButtonElement.remove();
            postButtonElement.remove();
        }
    })
}