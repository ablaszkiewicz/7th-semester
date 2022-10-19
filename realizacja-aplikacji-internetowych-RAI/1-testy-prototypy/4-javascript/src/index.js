const Dealership = require('./Dealership');
const Car = require('./Car');

// Dla uproszczenia uznajemy, że dzisiaj to dzień 0. Jutro to dzień 1 itd...

const dealership = new Dealership();
const car1 = new Car(0, 1500, 10, [], 100);
dealership.addCar(car1);

// Widać, że samochód jest dostępny do wypożyczenia
const availableCars = dealership.getAvailableCars(0, 1);
console.log(availableCars);

// Wypożyczamy samochód na 10 dni
dealership.rentCar(0, 0, 10); // length=1

// Widać, że samochód nie jest już dostępny do wypożyczenia w dniach 5-10
const availableCars2 = dealership.getAvailableCars(5, 10);
console.log(availableCars2); // length=0

// Oddajemy samochód przedwcześnie (5 dnia)
dealership.returnCar(0, 5);

// Widać, że samochód jest już dostępny do wypożyczenia w dniach 5-10
const availableCars3 = dealership.getAvailableCars(5, 10);
console.log(availableCars3); // length=1
