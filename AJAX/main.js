'use strict';

// AJAX stands for Async JavaScript and XML
// really means "Using DOM API to send requests over the internet"

function ajaxGet(
    url,
    success,
    failure = res => console.log(res)) {
    let xhr = new XMLHttpRequest();

    xhr.addEventListener("readystatechange", () => {
        console.log(`ready state is now: ${xhr.readyState}`);
        if (xhr.readyState === 4) {
            // recieved a response
            // get the response body
            let responseJSON = xhr.response;
            console.log(responseJSON);
            if (xhr >= 200 && xhr.status < 300) {
                // success
                success(xhr.response);

            }
            else {
                failure(xhr.response);
            }
        }
    });
    xhr.open("GET", url);
    xhr.send();
    console.log("request about to be sent.")


}


document.addEventListener("DOMContentLoaded", () => {
    let jokeHeader = document.getElementById("jokeHeader");
    let JokeBtn = document.getElementById("jokeBtn");

    JokeBtn.addEventListener("click", () => {
        ajaxGet("http://api.icndb.com/jokes/random/", response => {
            let responseObj = JSON.parse(response);
            console.log(responseObj);
            jokeHeader.innerText = responseObj;
            let joke = responseObj.value.joke;
            jokeHeader.innerText = joke;
        })
    });

    jokeFetchBtn.addEventListener("click", () => {
        fetch("http://api.icndb.com/jokes/random/")
            .then(response => response.json())
            .then(obj => {
                jokeHeader.innerText = obj.value.joke;
            }).catch(err => console.log(err));
    });
});

