import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  title = 'MatchwiseClient';

  constructor(private toastr: ToastrService) {}

  ngOnInit(): void {
    this.toastr.success("Toastr kütüphanesi başarılı bir şekilde çalışıyor.", "BAŞARILI")
  }

}
