'use strict';

module.exports = function (id, maxVelocity, velocity) {
  this.status = function () {
    return `STATUS: id=${id} maxVelocity=${maxVelocity} velocity=${velocity}`;
  };
  this.start = function (newVelocity) {
    velocity = newVelocity;
    if (velocity > maxVelocity) {
      maxVelocity = velocity;
    }
  };
  this.stop = function () {
    velocity = 0;
  };
};
