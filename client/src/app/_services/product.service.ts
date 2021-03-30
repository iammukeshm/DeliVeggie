import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { ProductModel } from '../models/product-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = 'https://localhost:44397/api/';

  constructor(private http: HttpClient) { }

  getAll() : Observable<ProductModel[]>
  {
    return this.http.get<any>(this.baseUrl + 'products/');
  }
  getById(id: string)
  {
    return this.http.get(this.baseUrl + 'products/' + id);
  }
}
