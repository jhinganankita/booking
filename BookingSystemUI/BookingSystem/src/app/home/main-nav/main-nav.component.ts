import { Component, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { IUser } from 'src/app/models/IUser';
import { Role } from 'src/app/models/Role';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {
  user?: IUser | null;
  isAuthenticated?: boolean | false;
  showHistory?: boolean | false;
  userRole?: string | false;
  routerLink?: string | false;
  title?: string;
  @ViewChild('commonLink') commonLink: any;

  constructor(private accountService: AccountService) { }

  ngOnInit() {

    this.accountService.user.subscribe((data) => {
      if (data && data.roleName) {
        this.isAuthenticated = true;

        if (data.roleName == Role.Admin) {
          this.title = "Admin Dashboard";
          this.routerLink = "/admin";
          this.showHistory = false;
        }
        else{
          this.title = "Booking Dashboard";
          this.showHistory = true;
          this.routerLink = "/booking";
        }
      }
      else{
        this.isAuthenticated = false;
        this.showHistory = true;
      }
    })

  }

  logout() {
    this.isAuthenticated = false;
    this.accountService.logout();
  }
}
