import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { BaseComponent } from '../../../base/base.component';
import { IndividualService } from '../../../../services/individual.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../../../enums/spinnerType';
import { AuthService } from '../../../../services/auth.service';

@Component({
  selector: 'app-individual-login',
  imports: [RouterLink],
  templateUrl: './individual-login.component.html',
  styleUrl: './individual-login.component.scss'
})
export class IndividualLoginComponent extends BaseComponent {

  constructor(
    spinnerService: NgxSpinnerService,
    private individualService: IndividualService,
    private authService: AuthService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    super(spinnerService);
    
  }

  async login(email: string, password: string){
    this.showSpinner(SpinnerType.BallScaleRippleMultiple);
    await this.individualService.login(email, password, () => {
      this.authService.identityCheck();

      this.activatedRoute.queryParams.subscribe(params => {
        const returnUrl: string = params["returnUrl"];
        if(returnUrl){
          this.router.navigate([returnUrl]);
        }
        else{
          this.router.navigate(['']);
        }
      })
      this.hideSpinner(SpinnerType.BallScaleRippleMultiple)
    });
  }

}
