import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'urls', pathMatch: 'full' },
  {
    path: 'login',
    loadComponent: () => import('./features/login/login.component').then((m) => m.LoginComponent),
  },
  {
    path: 'urls',
    loadComponent: () =>
      import('./features/short-urls/short-urls-table/short-urls-table.component').then(
        (m) => m.ShortUrlsTableComponent,
      ),
  },
  {
    path: 'urls/:id',
    canActivate: [authGuard],
    loadComponent: () =>
      import('./features/short-urls/short-url-info/short-url-info.component').then(
        (m) => m.ShortUrlInfoComponent,
      ),
  },
  {
    path: 'about',
    loadComponent: () => import('./features/about/about.component').then((m) => m.AboutComponent),
  },
  { path: '**', redirectTo: 'urls' },
];
