import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { CreateCorporate } from '../contracts/createCorporate';

@Injectable({
  providedIn: 'root'
})
export class CorporateService {

  constructor(private httpClientService: HttpClientService) { }

  create(corporate: CreateCorporate, successCallBack?: any) {
    this.httpClientService.post({
      controller: "Companies"
    }, corporate).subscribe(result => {
      successCallBack();
    })
  }

}
