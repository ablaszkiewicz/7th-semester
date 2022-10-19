import { Car } from './Car';

export class Rental {
  constructor(public car: Car, public startDate: number, public endDate: number) {}
}
