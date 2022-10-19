'use strict';

const Rental = require('./Rental');
const Car = require('./Car');

class Dealership {
  cars = [];
  rentals = [];

  addCar(car) {
    this.cars.push(car);
  }

  rentCar(carId, startDate, endDate) {
    const car = this.cars.find((car) => car.getId() == carId);
    if (!this.getAvailableCars(startDate, endDate).some((car) => car.getId() == carId)) {
      throw new Error('Car not available');
    }

    if (!car) {
      throw new Error('Car not found');
    }

    this.rentals.push(new Rental(car, startDate, endDate));
  }

  returnCar(carId, currentDay) {
    const rental = this.rentals.find(
      (rental) => rental.car.getId() == carId && rental.startDate < currentDay && rental.endDate > currentDay
    );

    if (!rental) {
      throw new Error('Rental not found');
    }

    if (rental.endDate != currentDay) {
      rental.endDate = currentDay;
    }
  }

  getAvailableCars(startDate, endDate) {
    return this.cars.filter((car) => {
      return !this.rentals.some((rental) => {
        return car === rental.car && startDate < rental.endDate && endDate > rental.startDate;
      });
    });
  }

  getTopRentedCars() {
    const cars = this.cars.slice();
    cars.sort((a, b) => {
      return (
        this.rentals.filter((rental) => rental.car === b).length -
        this.rentals.filter((rental) => rental.car === a).length
      );
    });
    return cars;
  }

  getTopDamagedCars() {
    const cars = this.cars.slice();
    cars.sort((a, b) => {
      return b.getDamages().length - a.getDamages().length;
    });
    return cars;
  }

  clear() {
    this.cars = [];
    this.rentals = [];
  }

  getCar(id) {
    const car = this.cars.find((car) => car.getId() == id);
    if (car) {
      return car;
    } else {
      throw new Error('Car not found');
    }
  }

  getCarsRentedForDay(day) {
    return this.rentals.filter((rental) => rental.startDate <= day && rental.endDate >= day);
  }
}

module.exports = Dealership;
