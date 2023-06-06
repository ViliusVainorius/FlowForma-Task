import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  readonly apiUrl = 'https://localhost:7080/api/';

  constructor( private http: HttpClient) { }

  //Products
  //-------------------------------------------------------------
  //Get products
  getProductList(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'Product/GetAll/');
  }

  //Get product by id
  getProductById(ProductId: number): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'Product/Get?id=' + ProductId);
  }

  //Add clothing type product
  addProductClothing(dept: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.apiUrl + 'Product/CreateClothing', dept, httpOptions);
  }

  //Add shoes type product
  addProductShoes(dept: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.apiUrl + 'Product/CreateShoes', dept, httpOptions);
  }

  //Delete product by id
  deleteProduct(ProductId: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + 'Product/Delete?id=' + ProductId, httpOptions);
  }
  //-------------------------------------------------------------

}
