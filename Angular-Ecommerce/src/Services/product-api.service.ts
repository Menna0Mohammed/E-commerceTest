import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct } from '../Models/i-product';
import { environment } from '../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class ProductApiService {

  constructor(private HttpClient : HttpClient) { 
    
  }

  GetAllProducts() : Observable<IProduct[]>
  {
    return this.HttpClient.get<IProduct[]>(`${environment.baseUrl}/product/GetAllProducts`);
  }


  GetById(id :number) : Observable<IProduct>{
    return this.HttpClient.get<IProduct>(`${environment.baseUrl}/product/${id}`)
  }

  AddProduct(prd: IProduct): Observable<IProduct> {
    return this.HttpClient.post<IProduct>(
      `${environment.baseUrl}/product/CreateProduct`,prd);
  }
  
   deleteProduct(id:number): Observable<void> {
    // check if id send or no
    console.log(id);
    
    return this.HttpClient.delete<void>(`${environment.baseUrl}/product/${id}`);
    
  }

  UpdateProduct(updatedProduct: IProduct): Observable<IProduct> {
    return this.HttpClient.put<IProduct>(
      `${environment.baseUrl}/product/UpdateProduct`,  
      updatedProduct // Send the whole object in the body
    );
  }
  
  


}
