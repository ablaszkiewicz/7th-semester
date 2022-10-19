export class Car {
  constructor(
    private id: number,
    private totalKilometers: number,
    private maxPassengers: number,
    private damages: string[],
    private pricePerDay: number
  ) {}

  public addDamage(damage: string) {}

  public getId() {
    return this.id;
  }

  public getDamages() {
    return this.damages;
  }
}
