import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { CreateIndividual } from '../contracts/createIndividual';
import { firstValueFrom, Observable } from 'rxjs';
import { CustomToastrService } from './custom-toastr.service';
import { Token } from '../contracts/token';
import { TokenResponse } from '../contracts/tokenResponse';
import { ToastrMessageType } from '../enums/toastrMessageType';
import { ToastrPosition } from '../enums/toastrPosition';

@Injectable({
  providedIn: 'root'
})
export class IndividualService {

  constructor(
    private httpClientService: HttpClientService,
    private customToastrService: CustomToastrService
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

  async login(email: string, password: string, callBackFunction?: () => void): Promise<any> {
    const observable: Observable<any | TokenResponse> = this.httpClientService.post<any | TokenResponse>({
      controller: "Candidate",
      action: "login"
    }, { email, password })
    const tokenResponse: TokenResponse = await firstValueFrom(observable) as TokenResponse;
    if (tokenResponse) {
      localStorage.setItem("accessToken", tokenResponse.token.accessToken);
      this.customToastrService.message("Kullanıcı girişi başarıyla sağlanmıştır.", "GİRİŞ BAŞARILI", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    callBackFunction();
  }

}
