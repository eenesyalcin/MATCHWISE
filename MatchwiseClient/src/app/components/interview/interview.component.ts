import { CommonModule } from '@angular/common';
import { Component, HostListener } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-interview',
  imports: [RouterLink, CommonModule],
  templateUrl: './interview.component.html',
  styleUrl: './interview.component.scss'
})
export class InterviewComponent {

  loginMenuOpen = false;

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

}
