function solve(password){

    let validPasswordLength = (password) => password.length >= 6 && password.length <= 10;
    let onlyLettersAndNumbers  = (password) => /^[A-Za-z0-9]*$/.test(password);

    let passwordContainsTwoDigits = (password) => password.split('')
                                                        .filter(char => Number.isInteger(Number(char)))
                                                        .length >= 2;

    const validations = [
        [validPasswordLength, 'Password must be between 6 and 10 characters'],
        [onlyLettersAndNumbers, 'Password must consist only of letters and digits'],
        [passwordContainsTwoDigits, 'Password must have at least 2 digits']
    ];


    const erroes = validations
        .map(([validator, message]) => validator(password) ? '' : message)
        .filter(message => !!message)

    erroes.forEach(message => console.log(message));

    if(erroes.length === 0){
        console.log('Password is valid');
    }

}

solve('Pa$s$s')
