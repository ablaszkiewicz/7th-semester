class Car {
  constructor(id, totalKilometers, maxPassengers, damages, pricePerDay) {
    this.id = id;
    this.totalKilometers = totalKilometers;
    this.maxPassengers = maxPassengers;
    this.damages = damages;
    this.pricePerDay = pricePerDay;
  }

  addDamage(damage) {}

  getId() {
    return this.id;
  }

  getDamages() {
    return this.damages;
  }
}

module.exports = Car;
