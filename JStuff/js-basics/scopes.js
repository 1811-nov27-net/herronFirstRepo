function my_func(a) {
    console.log(a);
}

var my_func2 = (function (a) {
    console.log(a)
});

var my_func3 = (a) => console.log(a);
var no_params = () => console.log();

var x=5;
x=5;

function f(){
    console.log(x);
    if(true){
        var y = 7
    }

    asdf = 'asdf';  // global scope.


    // in a function, "var" uses function scope.
    // this "y" is visible throughout my function, even at the top
    // before it is declared
}

// ES5 has "strict mode"
// has to be at top of file to work
'use strict';
// turns some silent errors into thrown errors.

// with strict mode, undeclared variables throw errors

// when you use let and const, variable only in scope within the nearest pair of braces.
// const prevents changing the value after first assignment.

// use let and const always, never var or undeclared.

let obj = {
    name: 'Nick',
    skill: 10000,
    sayName: function() {console.log(this.name)},
    sayName2() {console.log("My name is " + this.name)},

}
obj.arrow = () => {console.log(this.name)}, // points to Nick's name


obj.arrow();
// obj.sayName();
// obj.sayName2();

function Person(name, age){
    this.name = name;
    this.age = age;
    this.sayName = function(){console.log(this.name)}
    this.sayName2 = obj.sayName2;
    this.sayNicksName = obj.arrrow;
}

let fred = new Person("Fred", 78);
fred.sayName2();
fred.sayNicksName();

class Graduate {
    constructor(name, age, gradYear) {
        this.__proto__ = new Person(name, age);
        this.gradYear = gradYear;
    }
}

let nick = new Graduate("Nick", 26, 2014);
console.log(nick);

/*
new in ES6

arrow functions
let, const
class, interface
method syntax for functions as properties
string interpolation
symbol type for GUIDs
new useful built-in functions (string searching)
Promises for async stuff w/o callbacks
native modules (like namespaces)
built-in Set and Map structures
"for of" loop (like foreach)
getters and setters for properties like C#
internationalization

*/