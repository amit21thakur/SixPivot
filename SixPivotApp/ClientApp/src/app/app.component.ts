import { Component, ViewChild } from '@angular/core';
import { RateEventModel } from './models/rate.event.model';
import { OrderDetailsComponent } from './order-details/order-details.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
    @ViewChild("orderDetailsTag", { static: true }) orderDetailsComponent: OrderDetailsComponent;


    title = 'app';
    private rateEvent: RateEventModel;
    setCurrencyChange(event: RateEventModel) {
        this.rateEvent = event;
    }

    onItemAddedToOrder() {
        this.orderDetailsComponent.onProductAddedToOrder();
    }
}
