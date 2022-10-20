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
  this.getMaxVelocity = function () {
    return maxVelocity;
  };

  this.getId = function () {
    return id;
  };

  this.getVelocity = function () {
    return velocity;
  };
};
