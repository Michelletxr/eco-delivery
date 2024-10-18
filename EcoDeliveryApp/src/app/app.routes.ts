import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ReciboDetailComponent } from './recibo-detail/recibo-detail.component';
import { LoginPageComponent } from './login-page/login-page.component';

export const routes: Routes = [
    { path: 'dashboard/:id', component: DashboardComponent },
    { path: 'recibo/:id', component: ReciboDetailComponent },
    { path: 'login', component: LoginPageComponent },
];
