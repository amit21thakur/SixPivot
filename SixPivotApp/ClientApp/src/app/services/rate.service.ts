import { Injectable, Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RateModel } from '../models/rate.model';


@Injectable()
export class RateService{
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUri = baseUrl; }

    private baseUri:string;
    
    getRates(){
        var url = this.baseUri + "api/Rates";
        return this.http.get<RateModel[]>(url);
    }
}
