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

    // this.httpClientService.post({
    //   controller: "Companies"
    // }, {
    //   name: "Matchwise Teknoloji A.Ş.",
    //   industry: "Yazılım ve Bilişim",
    //   location: "Ankara, Türkiye"
    // }).subscribe();

    // this.httpClientService.put({
    //   controller: "Companies"
    // }, {
    //   id: "c57bc6dc-92a9-41ad-d595-08dd7560d48c",
    //   name: "Logo Yazılım A.Ş.",
    //   industry: "Yazılım Teknolojileri",
    //   location: "Kastamonu"
    // }).subscribe();

    this.httpClientService.delete({
      controller: "Companies"
    }, "c57bc6dc-92a9-41ad-d595-08dd7560d48c").subscribe();
  }

}
