console.log('main.js');

// dynamically typed
// only values have types.

// JavaScript is intrepreted, not compiled. In the Browser, or serverside w/ Node.JS

var x;

x = 5

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = 5.5

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = Infinity

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = -0

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = NaN

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = "abc"/2

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = "abc"

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = 'abc'

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

let y = 5
x = `Y is ${y}`

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = true

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = false

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x = {}

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

x.asdf = true
x.erver = 'abc'

console.log(x["asdf"])
console.log(x)

// arrays have syntax, but are objects.
x = [1, 2, 3]

console.log("Value of x: " + x);
console.log("type of x: " + typeof x);

// functions are first class objects

function my_function (a, b, c) {
    
}

// functions that don't have a return statement return undefined
// un-passed parameters will be undefined
// typeof calls functions functions, rather than objects

x = my_function(1, 2, 3);

x = my_function;
x.ser = 'stuff';


// symbol type...?
// unique ID's for things

