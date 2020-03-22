import { Component, OnInit } from '@angular/core';
import { OrderItemModel } from '../models/order.item.model';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

    private cookieName: string = "order-details";

    constructor(private cookieService: CookieService) { }

    orderItems: OrderItemModel[];
    name: string;
    emailAddress: string;

    onProductAddedToOrder() {
        this.orderItems = JSON.parse(this.cookieService.get(this.cookieName));
    }

    ngOnInit() {
        if (this.cookieService.check(this.cookieName)) {
            console.log('here');
            this.orderItems = JSON.parse(this.cookieService.get(this.cookieName));
        }
    }

    removeItem(index: number) {
        this.orderItems.splice(index, 1);
        this.cookieService.delete(this.cookieName);
        if (this.orderItems.length > 0) {
            this.cookieService.set(this.cookieName, JSON.stringify(this.orderItems));
        }
    }

    placeOrder() {
        console.log(this.name);
        console.log(this.emailAddress);
    }

}
