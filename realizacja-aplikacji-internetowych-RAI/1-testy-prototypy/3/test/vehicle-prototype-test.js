var expect = require('chai').expect;
const Vehicle = require('../src/vehicle-prototype');

describe('vehicle prototype tests', () => {
  it('should check if method added to prototype is callable', () => {
    const vehicle = new Vehicle(0);
    expect(vehicle.testFn()).equal('test');
  });

  it('should check if adding method to prototype after instantiation changes original instance', () => {
    const vehicle = new Vehicle(0);
    Vehicle.prototype.testFn = () => 'test2';
    expect(vehicle.testFn()).equal('test2');
  });

  it('should check if fields are public', () => {
    const vehicle = new Vehicle(0);
    vehicle.id = 1;
    vehicle.velocity = 1;
    vehicle.maxVelocity = 1;

    expect(vehicle.id).equal(1);
    expect(vehicle.velocity).equal(1);
    expect(vehicle.maxVelocity).equal(1);
  });

  it('should check availabivlity of field "prototype"', () => {
    const vehicle = new Vehicle(0);
    expect(vehicle.prototype).equal(undefined);
  });

  it('should check availabivlity of field "_prototype"', () => {
    const vehicle = new Vehicle(0);
    expect(vehicle._prototype).equal(undefined);
  });

  it('should check availabivlity of field "constructor"', () => {
    const vehicle = new Vehicle(0);
    expect(vehicle.constructor).equal(Vehicle);
  });
});
