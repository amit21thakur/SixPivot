import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ProductService } from '../services/product.service';
import { RateService } from '../services/rate.service';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-list/product-detail/product-detail.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { CookieService } from 'ngx-cookie-service';
import { OrderService } from '../services/order.service';

@NgModule({
  declarations: [
        AppComponent,
        NavMenuComponent,
        ProductListComponent,
        ProductDetailComponent,
        OrderDetailsComponent
  ],
  imports: [
      BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot([
    ])
    ],
    providers: [ProductService, RateService, CookieService, OrderService],
    bootstrap: [AppComponent]
})
export class AppModule { }
