import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { BaseComponent } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { IndividualService } from '../../../../services/individual.service';
import { CustomToastrService } from '../../../../services/custom-toastr.service';
import { SpinnerType } from '../../../../enums/spinnerType';
import { CreateIndividual } from '../../../../contracts/createIndividual';
import { ToastrMessageType } from '../../../../enums/toastrMessageType';
import { ToastrPosition } from '../../../../enums/toastrPosition';

@Component({
  selector: 'app-individual-register',
  imports: [RouterLink],
  templateUrl: './individual-register.component.html',
  styleUrl: './individual-register.component.scss'
})
export class IndividualRegisterComponent extends BaseComponent implements OnInit {

  constructor(
    spinnerService: NgxSpinnerService,
    private router: Router,
    private individualService: IndividualService,
    private customToastrService: CustomToastrService
  ) {  
    super(spinnerService);
  }

  ngOnInit(): void {

  }

  create(firstName: HTMLInputElement, lastName: HTMLInputElement, jobTitle: HTMLInputElement, email: HTMLInputElement, password: HTMLInputElement,){
    this.showSpinner(SpinnerType.BallScaleRippleMultiple);
    const create_individual: CreateIndividual = new CreateIndividual();
    create_individual.firstName = firstName.value;
    create_individual.lastName = lastName.value;
    create_individual.jobTitle = jobTitle.value;
    create_individual.email = email.value;
    create_individual.password = password.value;

    this.individualService.create(create_individual, () => {
      this.hideSpinner(SpinnerType.BallScaleRippleMultiple);
      this.customToastrService.message("Başarılı şekilde kaydınız oluşturuldu.", "KAYIT BAŞARILI", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
      this.router.navigate(['/bireysel-giris']);
    }, (errorMessages: string[]) => {
      this.hideSpinner(SpinnerType.BallScaleRippleMultiple);
      errorMessages.forEach(error => {
        this.customToastrService.message(error, "HATA", {
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight
        });
      });
    });
  }
  
}
