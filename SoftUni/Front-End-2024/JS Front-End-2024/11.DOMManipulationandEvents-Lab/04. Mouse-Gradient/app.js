function attachGradientEvents() {
    const gradientElement = document.getElementById('gradient');
    const resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (event) =>{
        resultElement.textContent = Math.floor((Number(event.offsetX) / 300) * 100) + '%';
    })
}