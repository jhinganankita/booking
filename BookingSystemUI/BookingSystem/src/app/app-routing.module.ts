import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookingComponent } from './home/booking/booking.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './helpers/auth.guard';
import { RoleGuard } from './guard/RoleGaurd';
import { AdminComponent } from './admin/admin.component';
import { TickethistoryComponent } from './home/tickethistory/tickethistory.component';
import { LoginComponent } from './account/login/login.component';
const accountModule = () => import('./account/account.module').then(x => x.AccountModule);

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'booking', component: BookingComponent, canActivate: [AuthGuard] },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [RoleGuard], data: { allowedRoles: ['admin'] } },
  { path: 'account', loadChildren: accountModule },
  { path: 'tickethistory', component: TickethistoryComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
