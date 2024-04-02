function attachEventsListeners() {
    const buttons = document.querySelectorAll('input[type=button]');
    const inputElements = document.querySelectorAll('input[type=text]');

    const toSeconds = (value, unit) => {
        switch(unit) {
            case'days':
                return value * 24 * 60 * 60;
            case'hours':
                return value * 60 * 60;
            case'minutes':
                return value * 60;
            case'hours':
                return value;
        }
    }

    const converters = {
        days(seconds) {
            return seconds / 60 / 60 / 24;
        },
        hours(seconds){
            return seconds / 60 / 60;
        },
        minutes(seconds){
            return seconds / 60;
        },
        seconds(seconds){
            return seconds;
        }
    }
    for(const button of buttons){
        button.addEventListener('click', function(e) {
            const currentInputElement = e.currentTarget.previousElementSibling;

            for(const inputElement of inputElements){
                const seconds = toSeconds(Number(currentInputElement.value), currentInputElement.id)
                inputElement.value = converters[inputElement.id](seconds);
            }
        });
    }
}