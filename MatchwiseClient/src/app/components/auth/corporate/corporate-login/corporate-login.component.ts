import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BaseComponent } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { CorporateService } from '../../../../services/corporate.service';
import { SpinnerType } from '../../../../enums/spinnerType';

@Component({
  selector: 'app-corporate-login',
  imports: [RouterLink],
  templateUrl: './corporate-login.component.html',
  styleUrl: './corporate-login.component.scss'
})
export class CorporateLoginComponent extends BaseComponent {

  constructor(
    spinnerService: NgxSpinnerService,
    private corporateService: CorporateService
  ) {
    super(spinnerService);
  }

  async login(email: string, password: string){
    this.showSpinner(SpinnerType.SquareJellyBox);
    await this.corporateService.login(email, password, () => this.hideSpinner(SpinnerType.SquareJellyBox));
  }

}
