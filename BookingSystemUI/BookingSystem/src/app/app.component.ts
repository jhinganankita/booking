import { Component } from '@angular/core';

import { AccountService } from './services/account.service';
import { IUser } from './models/IUser';
import { Role } from './models/Role';

@Component({ selector: 'app-root', templateUrl: 'app.component.html' })
export class AppComponent {
    user?: IUser | null;
    isAuthenticated?: boolean | false;
    userRole?: string | false;
    title?: string | "Booking Dashboard";

    constructor(private accountService: AccountService) {
        
    }

    ngOnInit() {
      // let userData = JSON.parse(localStorage.getItem('user') as string);
      // this.userRole = userData.roleName as string;

      // if (userData != null) {
      //   this.isAuthenticated = true;
      // }

      // if (this.userRole == Role.Admin){
      //   this.title = "Admin Dashboard";
      // }
    }


}
