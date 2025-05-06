import { Routes } from '@angular/router';
import { LayoutComponent } from './components/home/layout/layout.component';
import { AdminLayoutComponent } from './components/admin/admin-layout/admin-layout.component';
import { CorporateLayoutComponent } from './components/corporate/corporate-layout/corporate-layout.component';
import { IndividualLoginComponent } from './components/auth/individual/individual-login/individual-login.component';
import { IndividualRegisterComponent } from './components/auth/individual/individual-register/individual-register.component';
import { AdminLoginComponent } from './components/auth/admin/admin-login/admin-login.component';
import { AdminRegisterComponent } from './components/auth/admin/admin-register/admin-register.component';
import { CorporateLoginComponent } from './components/auth/corporate/corporate-login/corporate-login.component';
import { CorporateRegisterComponent } from './components/auth/corporate/corporate-register/corporate-register.component';
import { InterviewComponent } from './components/interview/interview.component';

export const routes: Routes = [
  { path: 'bireysel-giris', component: IndividualLoginComponent },
  { path: 'bireysel-kayit', component: IndividualRegisterComponent },
  { path: 'admin-giris', component: AdminLoginComponent },
  { path: 'admin-kayit', component: AdminRegisterComponent },
  { path: 'kurumsal-giris', component: CorporateLoginComponent },
  { path: 'kurumsal-kayit', component: CorporateRegisterComponent },

  {
    path: '',
    component: LayoutComponent,
    children: [

    ]
  },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      {
        path: 'corporations',
        loadComponent: () => import('../../src/app/components/admin/admin-layout/corporations/corporations.component').then(m => m.CorporationsComponent)
      },
      {
        path: "add-corporation",
        loadComponent: () => import('../../src/app/components/admin/admin-layout/add-corporation/add-corporation.component').then(m => m.AddCorporationComponent)
      }
    ]
  },
  {
    path: 'kurumsal',
    component: CorporateLayoutComponent
  },

  { path: 'mulakat', component: InterviewComponent },
];
