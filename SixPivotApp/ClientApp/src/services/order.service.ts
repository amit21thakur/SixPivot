import { Injectable, Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderItemModel } from '../models/order.item.model';


@Injectable()
export class OrderService{
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUri = baseUrl; }

    private baseUri:string;

    submitOrder(name: string, email: string, orderItems: OrderItemModel[]) {
        var url = this.baseUri + "api/Orders";
        return this.http.post(url,
            {
                "customerName": name,
                "customerEmail": email,
                "lineItems": orderItems
            }
        );
    }
}
