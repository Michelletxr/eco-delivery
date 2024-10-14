import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ReciboDetailComponent } from './recibo-detail/recibo-detail.component';

export const routes: Routes = [
    { path: '', component: DashboardComponent },
    { path: 'recibo/:id', component: ReciboDetailComponent },
];
