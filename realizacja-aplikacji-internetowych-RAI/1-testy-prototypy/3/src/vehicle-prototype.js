function Vehicle(id) {
  this.id = id;
  this.maxVelocity = 0;
  this.velocity = 0;
  this.status = function () {
    return `STATUS: id=${this.id} maxVelocity=${this.maxVelocity} velocity=${this.velocity}`;
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
}

Vehicle.prototype = {};
Vehicle.prototype.testFn = () => 'test';

module.exports = Vehicle;
