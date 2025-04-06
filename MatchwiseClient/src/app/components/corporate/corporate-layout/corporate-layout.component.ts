import { Component, OnInit } from '@angular/core';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from '../../base/base.component';
import { SpinnerType } from '../../../enums/spinnerType';
import { HttpClientService } from '../../../services/http-client.service';

@Component({
  selector: 'app-corporate-layout',
  imports: [],
  templateUrl: './corporate-layout.component.html',
  styleUrl: './corporate-layout.component.scss'
})
export class CorporateLayoutComponent extends BaseComponent implements OnInit {

  constructor(
    customSpinnerService: NgxSpinnerService,
    private httpClientService: HttpClientService
  ) {
    super(customSpinnerService);
  }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.BallScaleRippleMultiple);

    this.httpClientService.get({
      controller: "Companies"
    }).subscribe(data => console.log(data));
  }

}
