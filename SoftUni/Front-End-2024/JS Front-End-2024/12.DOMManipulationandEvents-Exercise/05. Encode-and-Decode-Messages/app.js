function encodeAndDecodeMessages() {
    const btnsElements = [...document.getElementsByTagName('button')];
    const textAreaElements = [...document.getElementsByTagName('textarea')];

    btnsElements[0].addEventListener('click', function(){
        let texttoEncode = textAreaElements[0].value;

        let encodetedText = '';
        for(let i = 0; i <  texttoEncode.length; i++){
            let number = Number(texttoEncode[i].charCodeAt(0)) + 1;
            encodetedText += String.fromCharCode(number);
            textAreaElements[0].value = '';
            textAreaElements[1].value = encodetedText;
        }
    })

    btnsElements[1].addEventListener('click', function(){
        let texttoEncode = textAreaElements[1].value;

        let encodetedText = '';
        for(let i = 0; i <  texttoEncode.length; i++){
            let number = Number(texttoEncode[i].charCodeAt(0)) - 1;
            encodetedText += String.fromCharCode(number);
            textAreaElements[1].value =  encodetedText;
        }
    })
}