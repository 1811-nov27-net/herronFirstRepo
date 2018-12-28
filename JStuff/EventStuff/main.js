'use strict';

function alertMe() {
    alert("You clicked the element");
}

/* 
window.onload = function () {
    let col1 = document.getElementById("col1");
    col1.onclick = alertMe;
        // this is the basic way of waiting until the document is all loaded.
}
 */

/* window.addEventListener("load", function () {
    let col1 = document.getElementById("col1");
    col1.onclick = alertMe;
        // waits until EVERYTHING is loaded.
});
 */

function printEventDetails(event) {
    console.log(event);
    console.log(event.target);
    console.log(this);
    
}

document.addEventListener("DOMContentLoaded", () =>{
    let col1 = document.getElementById("col1");
    col1.addEventListener("click", alertMe);
    // prefered method of doing this
    let header = document.getElementById("header");
    header.innerText += ", changed by JS";
    header.innerHTML = `<u>${header.innerHTML}</u>`;

    // getting tedious?
    // use JQuery, it's shorter!
    let cell1 = document.getElementById("cell1");
    cell1.addEventListener("click", printEventDetails);

    let tbody = document.getElementById("body");
    tbody.addEventListener("click", printEventDetails);

});

