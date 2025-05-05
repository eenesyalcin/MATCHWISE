import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { CreateIndividual } from '../contracts/createIndividual';

@Injectable({
  providedIn: 'root'
})
export class IndividualService {

  constructor(
    private httpClientService: HttpClientService
  ) { }

  create(individual: CreateIndividual, successCallBack?: any, errorCallBack?: any) {
      this.httpClientService.post({
        controller: "Candidates"
      }, individual).subscribe(result => {
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
