import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CustomToastrService } from '../services/custom-toastr.service';
import { ToastrMessageType } from '../enums/toastrMessageType';
import { ToastrPosition } from '../enums/toastrPosition';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../enums/spinnerType';

export const authGuard: CanActivateFn = (route, state) => {

  const jwtHelper = inject(JwtHelperService);
  const router    = inject(Router);
  const customToastrService = inject(CustomToastrService);
  const spinnerService = inject(NgxSpinnerService);

  spinnerService.show(SpinnerType.BallScaleRippleMultiple);
  const token: string = localStorage.getItem("accessToken");

  const decodeToken = jwtHelper.decodeToken(token);
  const expirationDate: Date = jwtHelper.getTokenExpirationDate(token);
  let expired: boolean;
  try {
    expired = jwtHelper.isTokenExpired(token);
  } catch {
    expired = true;
  }

  if(!token || expired){
    router.navigate(["bireysel-giris"], { queryParams: { returnUrl: state.url } });
    customToastrService.message("Oturum açmanız gerekiyor!", "YETKİSİZ ERİŞİM", {
      messageType: ToastrMessageType.Warning,
      position: ToastrPosition.TopRight
    });
  }

  spinnerService.hide(SpinnerType.BallScaleRippleMultiple);

  return true;

};
