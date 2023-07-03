import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService } from '../../services/account.service';
import { AlertService } from '../../services/alert.service';
import { Role } from '../../models/Role';

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
  form!: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private alertService: AlertService
  ) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.checkUserLoggedIn();
  }

  checkUserLoggedIn() {
    const currentPath = this.router.url;
    if (currentPath === '/') {
      // Redirect to "/account/login"
      this.router.navigate(['/account/login']);
    }
    const userData = JSON.parse(localStorage.getItem('user') as string);
    if (userData) {
      const userRole = userData.roleName as string;
      if (userRole == Role.Admin) {
        this.router.navigate(['/admin']);
      } else {
        this.router.navigate(['/booking']);
      }
    }
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit
    this.alertService.clear();

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.accountService.login(this.f['username'].value, this.f['password'].value)
      .pipe(first())
      .subscribe({
        next: (data: any) => {
          /* localStorage.setItem('userid',data.id as string);
          localStorage.setItem('username',data.username as string);
          localStorage.setItem('firstname', data.firstName as string);
          localStorage.setItem('lastname', data.lastName as string);*/
          // localStorage.setItem('userRole', data.roleName as string);

          if (data.roleName == Role.Admin) {
            this.router.navigate(['/admin']);
          } else {
            this.router.navigate(['/booking']);
          }
          // get return url from query parameters or default to home page
          // const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
          // this.router.navigateByUrl(returnUrl);
        },
        error: error => {
          this.alertService.error(error);
          this.loading = false;
        }
      });
  }
}
