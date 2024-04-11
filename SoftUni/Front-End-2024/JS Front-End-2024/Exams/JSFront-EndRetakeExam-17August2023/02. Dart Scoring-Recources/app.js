window.addEventListener("load", solve);

function solve() {
    const playerInputElement = document.getElementById('player');
    const scoreInputElement = document.getElementById('score');
    const roundInputElement = document.getElementById('round');
    const addButtonElement = document.getElementById('add-btn');
    const sureListElement = document.getElementById('sure-list');
    const scoreBoardElement = document.getElementById('scoreboard-list');
    const clearButtonElemen = document.querySelector('.clear');

    addButtonElement.addEventListener('click', () => {

      if(playerInputElement.value === '' ||
        scoreInputElement.value === '' ||
        roundInputElement.value === ''){
          return;
        }

        const okButtonElement = document.createElement('button');
        okButtonElement.classList.add('btn', 'ok');
        okButtonElement.textContent = 'ok';
        okButtonElement.addEventListener('click', addToScoreBoard);

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('btn', 'edit');
        editButtonElement.textContent = 'edit';
        editButtonElement.addEventListener('click', edit);

        const nameElement = document.createElement('p');
        nameElement.textContent = playerInputElement.value;
        const player = playerInputElement.value;

        const scoreElement = document.createElement('p');
        scoreElement.textContent = `Score: ${scoreInputElement.value}`;
        let score = scoreInputElement.value;

        const roundElement = document.createElement('p');
        roundElement.textContent = `Round: ${roundInputElement.value}`;
        let round = roundInputElement.value;

        const articleElement = document.createElement('article');
        articleElement.appendChild(nameElement);
        articleElement.appendChild(scoreElement);
        articleElement.appendChild(roundElement);

        const dartItemLiElement = document.createElement('li');
        dartItemLiElement.classList.add('dart-item');
        dartItemLiElement.appendChild(articleElement);
        dartItemLiElement.appendChild(editButtonElement);
        dartItemLiElement.appendChild(okButtonElement);

        sureListElement.appendChild(dartItemLiElement);

        addButtonElement.disabled = true;
        playerInputElement.value = '';
        scoreInputElement.value = '';
        roundInputElement.value = '';

        function edit(){
          playerInputElement.value = player;
          scoreInputElement.value = score;
          roundInputElement.value = round;

          sureListElement.innerHTML = '';
          addButtonElement.disabled = false;
        }

        function addToScoreBoard(){
          sureListElement.innerHTML = '';
          scoreBoardElement.appendChild(dartItemLiElement);
          editButtonElement.remove();
          okButtonElement.remove();
          addButtonElement.disabled = false;
        }
    })

    clearButtonElemen.addEventListener('click', () => {
      location.reload();
    })
  }
  