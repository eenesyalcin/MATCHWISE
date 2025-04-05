import { NgxSpinnerService } from "ngx-spinner";
import { SpinnerType } from "../../enums/spinnerType";

export class BaseComponent {

  constructor(private spinner: NgxSpinnerService) {}

  showSpinner(spinnerTypeName: SpinnerType){
    this.spinner.show(spinnerTypeName);

    setTimeout(() => this.hideSpinner(spinnerTypeName), 3000);
  }

  hideSpinner(spinnerTypeName: SpinnerType){
    this.spinner.hide(spinnerTypeName);
  }

}
