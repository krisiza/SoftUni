function attachEventsListeners() {
    const daysElement = document.getElementById('days');
    const hoursElement = document.getElementById('hours');
    const minutesElement = document.getElementById('minutes');
    const secondsElement = document.getElementById('seconds');
    const buttons = document.querySelectorAll('input[type=button]');

    for(const button of buttons){
        button.addEventListener('click', function() {
            if(button.id === 'daysBtn'){
                hoursElement.value = Number(daysElement.value) * 24;
                minutesElement.value = Number(hoursElement.value * 60);
                secondsElement.value = Number(minutesElement.value) * 60;
            }

            if(button.id === 'hoursBtn'){
                daysElement.value = Number(hoursElement.value) / 24;
                minutesElement.value = Number(hoursElement.value * 60);
                secondsElement.value = Number(minutesElement.value) * 60;
            }

            if(button.id === 'minutesBtn')
            {
                secondsElement.value = Number(minutesElement.value) * 60;
                hoursElement.value = Number(minutesElement.value) / 60;
                daysElement.value = Number(hoursElement.value) / 24;
            }

            if(button.id === 'secondsBtn')
            {
                minutesElement.value = Number(secondsElement.value) / 60;
                hoursElement.value = Number(minutesElement.value) / 60;
                daysElement.value = Number(hoursElement.value) / 24;
            }
        });
    }
}