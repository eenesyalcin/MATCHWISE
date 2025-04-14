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
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule, NgIf } from '@angular/common';

@Component({
  selector: 'app-corporate-register',
  imports: [RouterLink, ReactiveFormsModule, CommonModule, NgIf],
  templateUrl: './corporate-register.component.html',
  styleUrl: './corporate-register.component.scss'
})
export class CorporateRegisterComponent extends BaseComponent implements OnInit {

  validationForm: FormGroup = new FormGroup({});

  constructor(
    spinnerService: NgxSpinnerService,
    private router: Router,
    private corporateService: CorporateService,
    private customToastrService: CustomToastrService
  ) {
    super(spinnerService);
  }

  ngOnInit(): void {
    this.createValidationForm();
  }

  createValidationForm() {
    this.validationForm = new FormGroup({
      corporateName: new FormControl("", [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(10)
      ]),
      taxNumber: new FormControl("", [
        Validators.required,
        Validators.pattern(/^.{11}$/),
        Validators.pattern(/^[0-9]+$/),
        Validators.pattern(/^[1-9].*$/)
      ]),
      sector: new FormControl("", [
        Validators.required,
        Validators.maxLength(20),
        Validators.minLength(5)
      ]),
      location: new FormControl("", [
        Validators.maxLength(20),
        Validators.minLength(5)
      ]),
      email: new FormControl("", [
        Validators.required,
        Validators.email
      ]),
      password: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.pattern(/.*[A-Za-z].*/),
        Validators.pattern(/.*\d.*/)
      ]),
    })
  }

  getCorporateNameErrorMessage(): string {
    const control = this.validationForm.get('corporateName');
    const value = control?.value;
    if (control?.hasError('required')) return 'Şirket adı boş bırakılamaz';
    if (control?.hasError('minlength')) return 'Şirket adı en az 10 karakter olmalıdır';
    if (control?.hasError('maxlength')) return 'Şirket ismi en fazla 50 karakter olabilir';
    return '';
  }

  getTaxNumberErrorMessage(): string {
    const control = this.validationForm.get('taxNumber');
    const value = control?.value;
    if (control?.hasError('required')) return 'Vergi numarası boş bırakılamaz';
    if (!/^[0-9]+$/.test(value)) return 'Vergi numarası yalnızca rakamlardan oluşmalıdır';
    if (!/^.{11}$/.test(value)) return 'Vergi numarası 11 hane olmalıdır';
    if (!/^[1-9]/.test(value)) return 'Vergi numarası 0 ile başlayamaz';
    return '';
  }

  getSectorErrorMessage(): string {
    const control = this.validationForm.get('sector');
    const value = control?.value;
    if (control?.hasError('required')) return 'Sektör bilgisi boş bırakılamaz';
    if (control?.hasError('minlength')) return 'Sektör bilgisi en az 5 karakter olmalıdır';
    if (control?.hasError('maxlength')) return 'Sektör bilgisi en fazla 20 karakter olabilir';
    return '';
  }

  getLocationErrorMessage(): string {
    const control = this.validationForm.get('location');
    const value = control?.value;
    if (control?.hasError('minlength')) return 'Konum bilgisi en az 3 karakter olmalıdır';
    if (control?.hasError('maxlength')) return 'Konum bilgisi en fazla 20 karakter olabilir';
    return '';
  }

  getEmailErrorMessage(): string {
    const control = this.validationForm.get('email');
    if (control?.hasError('required')) return 'Email alanı boş bırakılamaz';
    if (control?.hasError('email')) return 'Lütfen geçerli bir email giriniz';
    return '';
  }

  getPasswordErrorMessage(): string {
    const control = this.validationForm.get('password');
    const value = control?.value;
    if (control?.hasError('required')) return 'Şifre alanı boş bırakılamaz';
    if (control?.hasError('minlength')) return 'Şifre en az 5 karakter olmalıdır';
    if (value && !/[A-Za-z]/.test(value)) return 'Şifre en az bir harf içermelidir';
    if (value && !/\d/.test(value)) return 'Şifre en az bir rakam içermelidir';
    return '';
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

    if (this.validationForm.valid) {
      this.corporateService.create(create_corporate, () => {
        this.hideSpinner(SpinnerType.SquareJellyBox);
        this.customToastrService.message("Başarılı bir şekilde kaydınız oluşturuldu.", "KAYIT BAŞARILI", {
          messageType: ToastrMessageType.Success,
          position: ToastrPosition.TopRight
        });
        this.router.navigate(['/kurumsal-giris']);
      }, (errorMessages: string[]) => {
        this.hideSpinner(SpinnerType.SquareJellyBox);
        errorMessages.forEach(error => {
          this.customToastrService.message(error, "HATA", {
            messageType: ToastrMessageType.Error,
            position: ToastrPosition.TopRight
          });
        });
      });
    }
  }

}
