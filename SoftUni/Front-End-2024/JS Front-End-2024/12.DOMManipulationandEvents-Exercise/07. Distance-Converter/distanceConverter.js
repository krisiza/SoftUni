function attachEventsListeners() {
    const buttonElement = document.getElementById('convert');
    const inputElement = document.getElementById('inputDistance');
    const outputElement = document.getElementById('outputDistance');
    const optionInputElements = document.getElementById('inputUnits');
    const optionOutputElements = document.getElementById('outputUnits');

    buttonElement.addEventListener('click', () =>{
        let selectedUnit = optionInputElements.options[optionInputElements.selectedIndex].value;      
        let outputUnit = optionOutputElements.options[optionOutputElements.selectedIndex].value;
        let result = 0;
     
        const convertor = {
            km:1000,
            m:1,
            cm:0.01,
            mm:0.001,
            mi:1609.34,
            yrd:0.9144,
            ft:0.3048,
            in:0.0254,
        }

        let valueInMeters = inputElement.value * convertor[selectedUnit];
        console.log(valueInMeters);
        result = valueInMeters / convertor[outputUnit];

        outputElement.value = result;
    })
}