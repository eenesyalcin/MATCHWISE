import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { CreateCompanyCommandRequest } from '../contracts/CreateCompanyCommandRequest';
import { CreateCompanyCommandResponse } from '../contracts/CreateCompanyCommandResponse';
import { firstValueFrom, Observable } from 'rxjs';
import { Token } from '../contracts/token';
import { CustomToastrService } from './custom-toastr.service';
import { ToastrMessageType } from '../enums/toastrMessageType';
import { ToastrPosition } from '../enums/toastrPosition';
import { TokenResponse } from '../contracts/tokenResponse';

@Injectable({
  providedIn: 'root'
})
export class CorporateService {

  constructor(
    private httpClientService: HttpClientService,
    private customToastrService: CustomToastrService,
    private router: Router
  ) { }


  create(
    request: CreateCompanyCommandRequest,
    successCallBack?: (message: string) => void,
    errorCallBack?: (errors: string[]) => void
  ) {
    // ► burada body: Partial<T> olarak beklediği için 'as any' ile geçiyoruz
    this.httpClientService
      .post<CreateCompanyCommandResponse>(
        { controller: 'Companies' },
        request as any
      )
      .subscribe(
        (response: CreateCompanyCommandResponse) => {
          if (response.success) {
            successCallBack?.(response.message);
          } else {
            errorCallBack?.([response.message]);
          }
        },
        (err: HttpErrorResponse) => {
          const messages: string[] = [];

          // 1) ModelState hatası (objeyse içindeki dizi’leri topla)
          if (err.status === 400 && err.error && typeof err.error === 'object') {
            Object.values(err.error).forEach(v => {
              if (Array.isArray(v)) messages.push(...v);
            });
          }
          // 2) Tekil mesaj (string döndüyse)
          else if (typeof err.error === 'string') {
            messages.push(err.error);
          }
          // 3) Diğer
          else {
            messages.push('Sunucuya bağlanırken bir hata oluştu.');
          }

          errorCallBack?.(messages);
        }
      );
  }


  getAll(successCallBack?: any, errorCallBack?: any) {
    this.httpClientService.get({
      controller: "Companies"
    }).subscribe(result => {
      successCallBack(result);
    }, (errorResponse: HttpErrorResponse) => {
      const _error: Array<{ key: string, value: Array<string> }> = errorResponse.error;
      let errorMessage: string[] = [];
      _error.forEach(errorVavlue => {
        errorVavlue.value.forEach(_errorValue => {
          errorMessage.push(_errorValue);
        });
      });
      errorCallBack(errorMessage);
    });
  }


  async login(email: string, password: string, callBackFunction?: () => void): Promise<any>{
        const observable: Observable<any | TokenResponse> = this.httpClientService.post<any | TokenResponse>({
          controller: "Companies",
          action: "login"
        }, { email, password })
        const tokenResponse: TokenResponse = await firstValueFrom(observable) as TokenResponse; 
        if(tokenResponse){
          localStorage.setItem("accessToken", tokenResponse.token.accessToken);
          this.customToastrService.message("Kullanıcı girişi başarıyla sağlanmıştır.", "GİRİŞ BAŞARILI", {
            messageType: ToastrMessageType.Success,
            position: ToastrPosition.TopRight
          });
        }
        callBackFunction();
      }

}
