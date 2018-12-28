'use strict';

document.addEventListener("DOMContentLoaded", () => {
    let jokeHeader = document.getElementById("jokeHeader");
    jokeFetchBtn.addEventListener("click", () => {
        fetch("https://geek-jokes.sameerkumar.website/api")
        .then(response => response.json())
        .then(obj => {
            console.log(obj)
            jokeHeader.innerText = obj;
        }).catch(err => console.log(err));
    });
});