import { Component, Output, EventEmitter } from '@angular/core';
import { RateService } from '../services/rate.service';
import { RateModel } from '../models/rate.model';
import { RateEventModel } from '../models/rate.event.model';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

    @Output() onCurrencyChanged = new EventEmitter<RateEventModel>();
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
    }

    constructor(private rateService: RateService) { }

    public rateEvent: RateEventModel;

    ngOnInit() {
        this.rateEvent = new RateEventModel("AUD", 1);
        this.onCurrencyChanged.emit(this.rateEvent);
    }

    onCurrencyChange(currency:string) {

        if (currency.localeCompare("AUD") === 0) {
            this.rateEvent = new RateEventModel(currency, 1);
            this.onCurrencyChanged.emit(this.rateEvent);
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
                    this.onCurrencyChanged.emit(this.rateEvent);
                },
                (err) => {
                    console.log(err)
                },
            );
        }

    }
}
