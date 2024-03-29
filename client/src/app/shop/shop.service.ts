import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl =  environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();
    if(shopParams.brandId !== 0) params = params.append('idBrand', shopParams.brandId.toString());
    if(shopParams.typeId !== 0) params = params.append('idType', shopParams.typeId.toString());
    if(shopParams.search) params = params.append('search', shopParams.search);
    
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());
    
    return this.http.get<IPagination>(`${this.baseUrl}products`, {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getProduct(id: number){
    return this.http.get<IProduct>(`${this.baseUrl}products/${id}`)
  }

  getBrands() {
    return this.http.get<IBrand[]>(`${this.baseUrl}products/brands`);
  }

  getProductsTypes(){
    return this.http.get<IProductType[]>(`${this.baseUrl}products/types`);
  }
}
