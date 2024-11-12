import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  BASE_API_URL = 'http://localhost:3002/api';

  constructor(private httpClient: HttpClient) { }

  getProducts():Observable<Product[]> {
    return this.httpClient.get<Product[]>(`${this.BASE_API_URL}/products`);
  }

  addProduct(product: Product):Observable<Product> {
    return this.httpClient.post<Product>(`${this.BASE_API_URL}/products`, product);
  }

  deleteProduct(id: string):Observable<Product> {
    return this.httpClient.delete<Product>(`${this.BASE_API_URL}/products/${id}`);
  }

  updateProduct(product: Product):Observable<Product> {
    return this.httpClient.put<Product>(`${this.BASE_API_URL}/products/${product.id}`, product);
  }
}
