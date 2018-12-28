function newCounter() {
    let x = 0;
    return () => ++x;
}

let counter = newCounter();

console.log(counter());
console.log(counter());
console.log(counter());

let counter2 = newCounter();

console.log(counter2());
console.log(counter2());
console.log(counter2());
