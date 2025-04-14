import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { CreateCorporate } from '../contracts/createCorporate';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CorporateService {

  constructor(
    private httpClientService: HttpClientService, 
    private router: Router
  ) { }

  create(corporate: CreateCorporate, successCallBack?: any, errorCallBack?: any) {
    this.httpClientService.post({
      controller: "Companies"
    }, corporate).subscribe(result => {
      successCallBack();
    }, (errorResponse: HttpErrorResponse) => {
      const _error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
      let errorMessages: string[] = [];
      _error.forEach(errorValue => {
        errorValue.value.forEach(_errorValue => {
          errorMessages.push(_errorValue);
        });
      });
      errorCallBack(errorMessages);
    });
  }

}
