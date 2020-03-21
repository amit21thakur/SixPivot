import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProductModel } from '../../models/product.model';
import { RateEventModel } from '../../models/rate.event.model';
import { CookieService } from 'ngx-cookie-service';
import { OrderItemModel } from '../../models/order.item.model';


@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent {


    constructor(private cookieService: CookieService) {

    }

    @Input() productItem: ProductModel;
    @Input() rateEvent: RateEventModel;
    @Output() onItemAdded = new EventEmitter<void>();


    public quantityToOrder: number = 0;

    public onQuantityChange(qty: number) {
        this.quantityToOrder = qty;
        console.log(this.quantityToOrder);
    }

    private cookieName: string = "order-details";

    public addProductToOrder() {
        var orderItems: OrderItemModel[] = [];
        if (this.cookieService.check(this.cookieName)) {
            orderItems = JSON.parse(this.cookieService.get(this.cookieName));
        }


        var index;
        var itemExists = false;

        for (index in orderItems) {
            if (orderItems[index].productId.localeCompare(this.productItem.productId) === 0) {
                itemExists = true;
                break;
            }
        }

        if (!itemExists) {
            orderItems.push(new OrderItemModel(this.productItem.productId, this.quantityToOrder, this.productItem.name));
        }
        else {
            orderItems[index].quantity = Number(orderItems[index].quantity) + Number(this.quantityToOrder);
        }
        this.cookieService.delete(this.cookieName);
        this.cookieService.set(this.cookieName, JSON.stringify(orderItems));
        this.onItemAdded.emit();
    }

}
