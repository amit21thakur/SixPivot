import { Component, OnInit } from '@angular/core';
import { OrderItemModel } from '../../models/order.item.model';
import { CookieService } from 'ngx-cookie-service';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

    private cookieName: string = "order-details";

    showErrorMsg = false;
    showSuccessMsg = false;

    constructor(private cookieService: CookieService, private orderService: OrderService) { }

    orderItems: OrderItemModel[];
    name: string;
    emailAddress: string;

    notifyErrorMessage() {
        this.showErrorMsg = true;

        setInterval(() => {
        this.showErrorMsg = false;
        }, 10000);
    }

    notifySuccessMessage() {
        this.showSuccessMsg = true;

        setInterval(() => {
            this.showSuccessMsg = false;
        }, 10000);
    }

    onProductAddedToOrder() {
        this.orderItems = JSON.parse(this.cookieService.get(this.cookieName));
    }

    ngOnInit() {
        if (this.cookieService.check(this.cookieName)) {
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

        this.orderService.submitOrder(
            this.name,
            this.emailAddress,
            JSON.parse(this.cookieService.get(this.cookieName))).subscribe(
                (response) => {
                    this.cookieService.delete(this.cookieName);
                    this.orderItems = [];
                    this.notifySuccessMessage();
                    this.name = "";
                    this.emailAddress = "";
                },
                (err) => {
                    console.log(err);
                    this.notifyErrorMessage();
                },
            );
    }

}
