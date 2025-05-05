import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { CreateIndividual } from '../contracts/createIndividual';
import { firstValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IndividualService {

  constructor(
    private httpClientService: HttpClientService
  ) { }

  create(individual: CreateIndividual, successCallBack?: any, errorCallBack?: any) {
      this.httpClientService.post({
        controller: "Candidate"
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

    async login(email: string, password: string, callBackFunction?: () => void): Promise<void>{
      const observable: Observable<any> = this.httpClientService.post({
        controller: "Candidate",
        action: "login"
      }, { email, password })
      await firstValueFrom(observable);
      callBackFunction();
    }
  
}
