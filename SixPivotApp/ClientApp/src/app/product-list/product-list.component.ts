import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ProductModel } from '../models/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css'],
    providers: [ProductService]
})
export class ProductListComponent implements OnInit {

    private items: Array<ProductModel> = [];

    constructor(private productService: ProductService) { }

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



}
