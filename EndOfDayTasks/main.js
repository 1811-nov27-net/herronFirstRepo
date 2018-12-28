'use strict';
document.addEventListener("DOMContentLoaded", () =>{
    let submission = document.getElementById("txtarea");
    let dabut = document.getElementById("dabut");
    dabut.addEventListener("click", () => {
        console.log(submission.value);
        console.log(JSON.parse(submission.innerText));
    });
});