'use strict';

// example 1
var a = 5;
console.log('Value of a is '.concat(a));

// example 2
var fn = function fn() {
  return 5;
};

//example 3
var undefinedTest = undefined;
console.log(undefinedTest === null || undefinedTest === void 0 ? void 0 : undefinedTest.test);
