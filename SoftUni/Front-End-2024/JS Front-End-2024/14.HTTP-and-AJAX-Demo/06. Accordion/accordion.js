async function solution() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const urlDetails = 'http://localhost:3030/jsonstore/advanced/articles/details/';

    const mainElement = document.querySelector('#main');

    // Fetch articles
    const response = await fetch(url);
    const articles = await response.json();

    // Fetch details for each article
    const fetchDetailsPromises = Object.values(articles).map(async article => {
        const response = await fetch(`${urlDetails}${article._id}`);
        const info = await response.json();
        return { article, info };
    });

    // Wait for all details to be fetched
    const articleDetails = await Promise.all(fetchDetailsPromises);

    // Create accordion items with details
    articleDetails.forEach(({ article, info }) => {
        const divAccordionElement = document.createElement('div');
        divAccordionElement.classList.add('accordion');
        
        const divHeadElement = document.createElement('div');
        divHeadElement.classList.add('head');

        const spanElement = document.createElement('span');
        spanElement.textContent = article.title;
        divHeadElement.appendChild(spanElement);

        const buttonMoreElement = document.createElement('button');
        buttonMoreElement.classList.add('button');
        buttonMoreElement.textContent = 'More';

        const divExtraElement = document.createElement('div');
        divExtraElement.classList.add('extra');
        divExtraElement.style.display = 'none';

        const pInfoElement = document.createElement('p');
        pInfoElement.textContent = info.content;
        divExtraElement.appendChild(pInfoElement);

        buttonMoreElement.addEventListener('click', () => {
            if (divExtraElement.style.display === 'none') {
                divExtraElement.style.display = 'block';
                buttonMoreElement.textContent = 'Less';
            } else {
                divExtraElement.style.display = 'none';
                buttonMoreElement.textContent = 'More';
            }
        });

        divHeadElement.appendChild(buttonMoreElement);
        divAccordionElement.appendChild(divHeadElement);
        divAccordionElement.appendChild(divExtraElement);
        mainElement.appendChild(divAccordionElement);
    });
}

solution();