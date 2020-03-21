import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ProductModel } from '../models/product.model';
import { RateEventModel } from '../models/rate.event.model';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
    styleUrls: [
        './product-list.component.css'
    ],
    providers: [ProductService]
})
export class ProductListComponent implements OnInit {

    private items: Array<ProductModel> = [];

    constructor(private productService: ProductService) { }

    @Input() rateEvent: RateEventModel;
    @Output() onItemAdded = new EventEmitter<void>();

    ngOnInit() {
        this.productService.getAllProducts().subscribe(
            (response) => {
                this.items = response;
                console.log(response);

            },
            (err) => {
                console.log(err)
            },

        );
    }

    OnItemAddedToOrder() {
        this.onItemAdded.emit();
    }



}
