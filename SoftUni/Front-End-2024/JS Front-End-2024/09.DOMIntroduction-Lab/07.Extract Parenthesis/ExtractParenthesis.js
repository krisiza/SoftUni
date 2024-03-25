function extract(content) {
    const textElement = document.getElementById(content);

    const matches = textElement.textContent.matchAll(/\(([a-zA-Z ]+)\)/g);

    return Array
        .from(matches)
        .map(match => match[1])
        .join('; ');
}