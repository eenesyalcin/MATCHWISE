import { Routes } from '@angular/router';
import { LayoutComponent } from './components/home/layout/layout.component';
import { AdminLayoutComponent } from './components/admin/admin-layout/admin-layout.component';

export const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
          
        ]
      },
      {
        path: 'admin',
        component: AdminLayoutComponent
      }
];
