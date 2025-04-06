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
export class AppComponent implements OnInit {

  title = 'MatchwiseClient';

  constructor(private customToastrService: CustomToastrService) {}

  ngOnInit(): void {
    this.customToastrService.message("Toastr kütüphanesi başarılı bir şekilde çalışıyor.", "BAŞARILI", {
      messageType: ToastrMessageType.Success,
      position: ToastrPosition.TopRight
    });

    const interviewId: string = "cafc0771-1a1a-4637-91ae-e386d33aaa4b"
    $.get(`https://localhost:7103/api/Interviews?id=${interviewId}`, data => {
      console.log(data);
    });
  }

}
