import { Component } from '@angular/core';
import { RateEventModel } from './models/rate.event.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
    title = 'app';
    private rateEvent: RateEventModel;
    setCurrencyChange(event: RateEventModel) {
        this.rateEvent = event;
    }
}
