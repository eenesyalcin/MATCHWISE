import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomToastrService } from './services/custom-toastr.service';
import { ToastrMessageType } from './enums/toastrMessageType';
import { ToastrPosition } from './enums/toastrPosition';
import { NgxSpinnerModule } from 'ngx-spinner';

declare var $: any;

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NgxSpinnerModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {

  title = 'MatchwiseClient';

}
