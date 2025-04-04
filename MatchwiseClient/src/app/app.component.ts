import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CustomToastrService } from './services/custom-toastr.service';
import { ToastrMessageType } from './enums/toastrMessageType';
import { ToastrPosition } from './enums/toastrPosition';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
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
  }

}
