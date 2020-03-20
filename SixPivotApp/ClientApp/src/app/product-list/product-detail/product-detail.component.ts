import { Component, Input } from '@angular/core';
import { ProductModel } from '../../models/product.model';
import { RateEventModel } from '../../models/rate.event.model';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent {

    @Input() productItem: ProductModel;
    @Input() rateEvent: RateEventModel;

  
}
