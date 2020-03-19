import { Injectable, Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductModel } from '../models/product.model';


@Injectable()
export class ProductService{
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUri = baseUrl; }

    private baseUri:string;
    
    getAllProducts(){
        var url = this.baseUri + "api/Products";
        return this.http.get<ProductModel[]>(url);
    }
}
