import { Car } from './Car';
import { Rental } from './Rental';

export class Dealership {
  private cars: Car[] = [];
  private rentals: Rental[] = [];

  public addCar(car: Car) {
    this.cars.push(car);
  }

  public rentCar(carId: number, startDate: number, endDate: number) {
    const car = this.cars.find((car) => car.getId() == carId);
    if (!this.getAvailableCars(startDate, endDate).some((car) => car.getId() == carId)) {
      throw new Error('Car not available');
    }

    if (!car) {
      throw new Error('Car not found');
    }

    this.rentals.push(new Rental(car, startDate, endDate));
  }

  public returnCar(carId: number, currentDay: number) {
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

  public getAvailableCars(startDate: number, endDate: number) {
    return this.cars.filter((car) => {
      return !this.rentals.some((rental) => {
        return car === rental.car && startDate < rental.endDate && endDate > rental.startDate;
      });
    });
  }

  public getTopRentedCars() {
    const cars = this.cars.slice();
    cars.sort((a, b) => {
      return (
        this.rentals.filter((rental) => rental.car === b).length -
        this.rentals.filter((rental) => rental.car === a).length
      );
    });
    return cars;
  }

  public getTopDamagedCars() {
    const cars = this.cars.slice();
    cars.sort((a, b) => {
      return b.getDamages().length - a.getDamages().length;
    });
    return cars;
  }

  public clear() {
    this.cars = [];
    this.rentals = [];
  }

  public getCar(id: number) {
    const car = this.cars.find((car) => car.getId() == id);
    if (car) {
      return car;
    } else {
      throw new Error('Car not found');
    }
  }

  public getCarsRentedForDay(day: number) {
    return this.rentals.filter((rental) => rental.startDate <= day && rental.endDate >= day);
  }
}
