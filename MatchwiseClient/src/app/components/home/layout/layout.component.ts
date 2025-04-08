import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { ContentComponent } from './content/content.component';
import { FooterComponent } from './footer/footer.component';
import { RouterOutlet } from '@angular/router';
import { NgxSpinnerModule, NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from '../../base/base.component';
import { SpinnerType } from '../../../enums/spinnerType';

@Component({
  selector: 'app-layout',
  imports: [NavbarComponent, ContentComponent, FooterComponent, RouterOutlet, NgxSpinnerModule],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {

}
