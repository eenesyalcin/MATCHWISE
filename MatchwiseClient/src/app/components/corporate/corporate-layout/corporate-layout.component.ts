import { Component, OnInit } from '@angular/core';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-corporate-layout',
  imports: [],
  templateUrl: './corporate-layout.component.html',
  styleUrl: './corporate-layout.component.scss'
})
export class CorporateLayoutComponent implements OnInit {

  constructor(private spinnerService: NgxSpinnerService) {}

  ngOnInit(): void {
    this.spinnerService.show();
  }

}
