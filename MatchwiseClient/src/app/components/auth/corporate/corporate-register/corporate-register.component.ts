import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CorporateService } from '../../../../services/corporate.service';
import { CreateCorporate } from '../../../../contracts/createCorporate';
import { BaseComponent } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../../../enums/spinnerType';
import { CustomToastrService } from '../../../../services/custom-toastr.service';
import { ToastrMessageType } from '../../../../enums/toastrMessageType';
import { ToastrPosition } from '../../../../enums/toastrPosition';

@Component({
  selector: 'app-corporate-register',
  imports: [RouterLink],
  templateUrl: './corporate-register.component.html',
  styleUrl: './corporate-register.component.scss'
})
export class CorporateRegisterComponent extends BaseComponent {

  constructor(
    spinnerService: NgxSpinnerService,
    private router: Router,
    private corporateService: CorporateService,
    private customToastrService: CustomToastrService) {
    super(spinnerService);
  }

  create(corporateName: HTMLInputElement, taxNumber: HTMLInputElement, sector: HTMLInputElement, location: HTMLInputElement, email: HTMLInputElement, password: HTMLInputElement) {
    this.showSpinner(SpinnerType.SquareJellyBox);
    const create_corporate: CreateCorporate = new CreateCorporate();
    create_corporate.corporateName = corporateName.value;
    create_corporate.taxNumber = taxNumber.value;
    create_corporate.sector = sector.value;
    create_corporate.location = location.value;
    create_corporate.email = email.value;
    create_corporate.password = password.value;

    this.corporateService.create(create_corporate, () => {
      this.hideSpinner(SpinnerType.SquareJellyBox);
      this.customToastrService.message("Başarılı bir şekilde kaydınız oluşturuldu.", "KAYIT BAŞARILI", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
      this.router.navigate(['/kurumsal-giris']);
    });
  }

}
