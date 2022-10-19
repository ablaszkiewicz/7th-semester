module.exports = function Vehicle(id) {
  this.id = id;
  this.maxVelocity = 0;
  this.velocity = 0;
  this.status = function () {
    console.log(`STATUS: id=${this.id} maxVelocity=${this.maxVelocity} velocity=${this.velocity}`);
  };
  this.start = function (velocity) {
    this.velocity = velocity;
    if (this.velocity > this.maxVelocity) {
      this.maxVelocity = this.velocity;
    }
  };
  this.stop = function () {
    this.velocity = 0;
  };
};

const vehicle = new Vehicle(0, 100, 0);
vehicle.status();
