import { Component, OnInit } from '@angular/core';
import { GetAllCorporate } from '../../../../contracts/getAllCorporate';
import { CorporateService } from '../../../../services/corporate.service';
import { BaseComponent } from '../../../base/base.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../../../enums/spinnerType';
import { CustomToastrService } from '../../../../services/custom-toastr.service';
import { ToastrMessageType } from '../../../../enums/toastrMessageType';
import { ToastrPosition } from '../../../../enums/toastrPosition';
import { CommonModule, NgFor } from '@angular/common';

@Component({
  selector: 'app-corporations',
  imports: [NgFor, CommonModule],
  templateUrl: './corporations.component.html',
  styleUrl: './corporations.component.scss'
})
export class CorporationsComponent extends BaseComponent implements OnInit {

  corporations: GetAllCorporate[] = [];

  constructor(
    spinnerService: NgxSpinnerService,
    private corporateService: CorporateService,
    private customToastrService: CustomToastrService
  ) {
    super(spinnerService);
  }

  ngOnInit(): void {
    this.getAllCorporate();
  }


  getAllCorporate() {
    this.showSpinner((SpinnerType.Cog));
    this.corporateService.getAll((data: GetAllCorporate[]) => {
      this.hideSpinner(SpinnerType.Cog);
      this.corporations = data;
      this.customToastrService.message("BAŞARILI", "Kurumlar başarıyla yüklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }, (errorMessages: string[]) => {
      this.hideSpinner(SpinnerType.Cog);
      errorMessages.forEach(error => {
        this.customToastrService.message(error, "HATA", {
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight
        });
      });
    });
  }

}
