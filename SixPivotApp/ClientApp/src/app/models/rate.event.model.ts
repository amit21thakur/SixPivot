export class RateEventModel {
    public selectedCurrency: string;
    public selectedRate: number;

    constructor(currency: string, rate: number) {
        this.selectedCurrency = currency;
        this.selectedRate = rate;
    }
}
