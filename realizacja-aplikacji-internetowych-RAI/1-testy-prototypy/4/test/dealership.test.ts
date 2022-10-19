import { Car } from '../src/Car';
import { Dealership } from '../src/Dealership';

describe('dealership tests', () => {
  const dealership = new Dealership();

  beforeEach(() => {
    dealership.clear();

    const car1 = new Car(0, 1500, 10, [], 100);
    dealership.addCar(car1);

    const car2 = new Car(1, 1500, 10, [], 100);
    dealership.addCar(car2);
  });

  it('should return two cars available to rent', () => {
    const availableCars = dealership.getAvailableCars(0, 1);
    expect(availableCars.length).toBe(2);
  });

  it('should return 1 car after renting one', () => {
    dealership.rentCar(0, 0, 10);
    const availableCars = dealership.getAvailableCars(0, 1);
    expect(availableCars.length).toBe(1);
  });

  it('should handle returning car before end of rental', () => {
    dealership.rentCar(0, 0, 10);
    dealership.returnCar(0, 5);
    const availableCars = dealership.getAvailableCars(5, 10);
    expect(availableCars.length).toBe(2);
  });

  it('should return top rented cars in correct order', () => {
    dealership.rentCar(0, 0, 1);
    dealership.rentCar(1, 0, 1);
    dealership.rentCar(1, 2, 3);
    dealership.rentCar(1, 4, 5);

    const topRentedCars = dealership.getTopRentedCars();
    expect(topRentedCars[0].getId()).toBe(1);
    expect(topRentedCars[1].getId()).toBe(0);
  });

  it('should return top damaged cars in correct order', () => {
    const car1 = dealership.getCar(0);
    car1.addDamage('Scratch');
    car1.addDamage('Scratch');
    car1.addDamage('Scratch');
    car1.addDamage('Scratch');

    const car2 = dealership.getCar(1);
    car2.addDamage('Scratch');
    car2.addDamage('Scratch');

    const topDamagedCars = dealership.getTopDamagedCars();
    expect(topDamagedCars[0].getId()).toBe(0);
    expect(topDamagedCars[1].getId()).toBe(1);
  });

  it('should not let you rent a car that is not available', () => {
    dealership.rentCar(0, 0, 1);
    expect(() => dealership.rentCar(0, 0, 1)).toThrow();
  });

  it('should throw an error if car is not found', () => {
    expect(() => dealership.rentCar(2, 0, 1)).toThrow();
  });

  it('should return list of cars rented for some day', () => {
    dealership.rentCar(0, 0, 1);
    dealership.rentCar(1, 0, 1);
    dealership.rentCar(1, 2, 3);
    dealership.rentCar(1, 4, 5);

    const carsRented = dealership.getCarsRentedForDay(0);
    expect(carsRented.length).toBe(2);
  });
});
