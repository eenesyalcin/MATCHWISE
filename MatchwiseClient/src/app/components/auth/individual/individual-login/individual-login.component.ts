import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BaseComponent } from '../../../base/base.component';
import { IndividualService } from '../../../../services/individual.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../../../enums/spinnerType';

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
  ) {
    super(spinnerService);
    
  }

  async login(email: string, password: string){
    this.showSpinner(SpinnerType.BallScaleRippleMultiple);
    await this.individualService.login(email, password, () => this.hideSpinner(SpinnerType.BallScaleRippleMultiple));
  }

}
