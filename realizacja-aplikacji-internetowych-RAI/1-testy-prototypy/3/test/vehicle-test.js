var expect = require('chai').expect;
const Vehicle = require('../src/vehicle');

describe('vehicle methods tests', () => {
  it('should check if new vehicle can be created', () => {
    expect(() => new Vehicle(0)).to.not.throw();
  });

  it('should check if status() method works', () => {
    const vehicle = new Vehicle(0, 0, 0);
    const expectedStatus = 'STATUS: id=0 maxVelocity=0 velocity=0';
    const status = vehicle.status();

    expect(status).equal(expectedStatus);
  });

  it('should check if start() method works', () => {
    const vehicle = new Vehicle(0, 0, 0);
    const expectedStatus = 'STATUS: id=0 maxVelocity=10 velocity=10';
    vehicle.start(10);
    const status = vehicle.status();

    expect(status).equal(expectedStatus);
  });

  it('should check if stop() method works', () => {
    const vehicle = new Vehicle(0, 0, 0);
    const expectedStatus = 'STATUS: id=0 maxVelocity=10 velocity=0';
    vehicle.start(10);
    vehicle.stop();
    const status = vehicle.status();

    expect(status).equal(expectedStatus);
  });
});

describe('vehicle fields tests', () => {
  it('should check if id field is set', () => {
    const vehicle = new Vehicle(0, 0, 0);
    expect(vehicle.id).equal(undefined);
  });

  it('should check if maxVelocity field is set', () => {
    const vehicle = new Vehicle(0, 0, 0);
    expect(vehicle.maxVelocity).equal(undefined);
  });

  it('should check if velocity field is set', () => {
    const vehicle = new Vehicle(0, 0, 0);
    expect(vehicle.velocity).equal(undefined);
  });
});

describe('vehicle logic tests', () => {
  it('should check if maxVelocity is updated', () => {
    const vehicle = new Vehicle(0, 0, 0);
    const expectedStatus = 'STATUS: id=0 maxVelocity=20 velocity=20';
    vehicle.start(10);
    vehicle.start(20);
    expect(vehicle.status()).equal(expectedStatus);
  });
});
