import { Inject, Injectable } from '@angular/core';
import { RequestParameters } from '../models/requestParameters';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(
    private httpClient: HttpClient,
    @Inject("baseUrl") private baseUrl: string
  ) { }


  private url(requestParameter: Partial<RequestParameters>): string {
    if(requestParameter.baserUrl){
      if(requestParameter.action){
        return `${requestParameter.baserUrl}/${requestParameter.controller}/${requestParameter.action}`;
      }else{
        return `${requestParameter.baserUrl}/${requestParameter.controller}`;
      }
    }else{
      if(requestParameter.action){
        return `${this.baseUrl}/${requestParameter.controller}/${requestParameter.action}`;
      }else{
        return `${this.baseUrl}/${requestParameter.controller}`;
      }
    }
  }


  get<T>(requestParameter: Partial<RequestParameters>, id?: string): Observable<T>{
    let url: string = "";
    if(requestParameter.fullEndPoint){
      url = requestParameter.fullEndPoint;
    }else{
      if(id){
        url = `${this.url(requestParameter)}/${id}`;
      }else{
        url = `${this.url(requestParameter)}`;
      }
    }

    return this.httpClient.get<T>(url, { headers: requestParameter.headers });
  }


  post<T>(requestParameter: Partial<RequestParameters>, body: Partial<T>): Observable<T>{
    let url: string = "";
    if(requestParameter.fullEndPoint){
      url = requestParameter.fullEndPoint;
    }else{
      url = `${this.url(requestParameter)}`;
    }

    return this.httpClient.post<T>(url, body, { headers: requestParameter.headers });
  }


  put<T>(requestParameter: Partial<RequestParameters>, body: Partial<T>): Observable<T>{
    let url: string = "";
    if(requestParameter.fullEndPoint){
      url = requestParameter.fullEndPoint;
    }else{
      url = `${this.url(requestParameter)}`;
    }

    return this.httpClient.put<T>(url, body, { headers: requestParameter.headers });
  }


  delete<T>(requestParameter: Partial<RequestParameters>, id:string): Observable<T>{
    let url: string = "";
    if(requestParameter.fullEndPoint){
      url = requestParameter.fullEndPoint;
    }else{
      url = `${this.url(requestParameter)}/${id}`;
    }

    return this.httpClient.delete<T>(url, { headers: requestParameter.headers });
  }

}
