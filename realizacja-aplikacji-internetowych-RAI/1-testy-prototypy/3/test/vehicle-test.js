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
    const expectedVelocity = 10;
    const expectedMaxVelocity = 10;
    vehicle.start(10);

    expect(vehicle.getVelocity()).equal(expectedVelocity);
    expect(vehicle.getMaxVelocity()).equal(expectedMaxVelocity);
  });

  it('should check if stop() method works', () => {
    const vehicle = new Vehicle(0, 0, 0);
    const expectedVelocity = 0;
    const expectedMaxVelocity = 10;
    vehicle.start(10);
    vehicle.stop();

    expect(vehicle.getVelocity()).equal(expectedVelocity);
    expect(vehicle.getMaxVelocity()).equal(expectedMaxVelocity);
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
    const expectedMaxVelocity = 20;
    vehicle.start(10);
    vehicle.start(20);
    expect(vehicle.getMaxVelocity()).equal(expectedMaxVelocity);
  });
});
