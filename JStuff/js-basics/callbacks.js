'use strict';

function addNumbers(a, b, callback) {
    let result = a + b;
    return callback(result);
}

addNumbers(3,4,console.log);  // prints 7

addNumbers(3,4, thing => console.log("calculation doen"));

