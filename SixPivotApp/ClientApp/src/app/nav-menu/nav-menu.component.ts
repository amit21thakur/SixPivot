import { Component } from '@angular/core';
import { RateService } from '../services/rate.service';
import { RateModel } from '../models/rate.model';
import { RateEventModel } from '../models/rate.event.model';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
    }

    constructor(private rateService: RateService) { }

    public rateEvent: RateEventModel = new RateEventModel("AUD", 1);

    onCurrencyChange(currency:string) {

        if (currency.localeCompare("AUD") === 0) {
            this.rateEvent = new RateEventModel(currency, 1);
        }
        else {
            this.rateService.getRates().subscribe(
                (response) => {
                    for (let rate of response) {
                        if (rate.targetCurrency.localeCompare(currency) === 0
                            && rate.sourceCurrency.localeCompare("AUD") === 0) {
                            this.rateEvent = new RateEventModel(currency, rate.rate);
                            break;
                        }
                    }
                },
                (err) => {
                    console.log(err)
                },
            );
        }

    }
}
