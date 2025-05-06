import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CustomToastrService } from '../services/custom-toastr.service';
import { ToastrMessageType } from '../enums/toastrMessageType';
import { ToastrPosition } from '../enums/toastrPosition';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../enums/spinnerType';
import { _isAuthenticated } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {

  const jwtHelper = inject(JwtHelperService);
  const router    = inject(Router);
  const customToastrService = inject(CustomToastrService);
  const spinnerService = inject(NgxSpinnerService);

  spinnerService.show(SpinnerType.BallScaleRippleMultiple);

  if(!_isAuthenticated){
    router.navigate(["bireysel-giris"], { queryParams: { returnUrl: state.url } });
    customToastrService.message("Oturum açmanız gerekiyor!", "YETKİSİZ ERİŞİM", {
      messageType: ToastrMessageType.Warning,
      position: ToastrPosition.TopRight
    });
  }

  spinnerService.hide(SpinnerType.BallScaleRippleMultiple);

  return true;

};
