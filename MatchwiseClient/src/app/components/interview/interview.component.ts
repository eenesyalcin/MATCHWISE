import { CommonModule } from '@angular/common';
import { Component, HostListener } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CustomToastrService } from '../../services/custom-toastr.service';
import { ToastrMessageType } from '../../enums/toastrMessageType';
import { ToastrPosition } from '../../enums/toastrPosition';

@Component({
  selector: 'app-interview',
  imports: [CommonModule],
  templateUrl: './interview.component.html',
  styleUrl: './interview.component.scss'
})
export class InterviewComponent {

  loginMenuOpen = false;

  constructor(
    public authService: AuthService,
    private customToastrService: CustomToastrService,
    private router: Router
  ){
    authService.identityCheck();
  }

  toggleLoginMenu() {
    this.loginMenuOpen = !this.loginMenuOpen;
  }

  @HostListener('document:click', ['$event'])
  handleClickOutside(event: MouseEvent) {
    const target = event.target as HTMLElement;
    if (!target.closest('.btn-group')) {
      this.loginMenuOpen = false;
    }
  }

  signOut(){
    localStorage.removeItem("accessToken");
    this.authService.identityCheck();
    this.router.navigate(['']);
    this.customToastrService.message("Oturumunuz kapatılmıştır", "OTURUM KAPATILDI", {
      messageType: ToastrMessageType.Info,
      position: ToastrPosition.TopRight
    });
  }

}
