import { Component } from '@angular/core';
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
  userRole?: string | false;
  title?: string;

  constructor(private accountService: AccountService) { }

  ngOnInit() {

    this.accountService.user.subscribe((data) => {
      if (data && data.roleName) {
        this.isAuthenticated = true;


        if (data.roleName == Role.Admin) {
          this.title = "Admin Dashboard";
        }
        else{
          this.title = "Booking Dashboard";
        }
      }
      else{
        this.isAuthenticated = false;
      }
    })

  }

  logout() {
    this.isAuthenticated = false;
    this.accountService.logout();
  }
}
