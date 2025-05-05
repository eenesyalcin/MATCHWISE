import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { CreateCompanyCommandRequest } from '../contracts/CreateCompanyCommandRequest';
import { CreateCompanyCommandResponse } from '../contracts/CreateCompanyCommandResponse';

@Injectable({
  providedIn: 'root'
})
export class CorporateService {

  constructor(
    private httpClientService: HttpClientService,
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

}
