import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService } from '../../services/account.service';
import { AlertService } from '../../services/alert.service';
import { ConfirmedValidator } from '../../validators/confirmed.validator';
import { IScheduleRequest } from 'src/app/models/IScheduleRequest';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {
    form!: FormGroup;
    loading = false;
    submitted = false;
    emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
    namePattern = "^[a-z0-9_-]{2,20}$";

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private accountService: AccountService,
        private alertService: AlertService
    ) { }

    ngOnInit() {

        this.form = this.formBuilder.group({
            firstName: ['', [Validators.required, Validators.pattern(this.namePattern), Validators.maxLength(20)]],
            lastName: ['', [Validators.required, Validators.pattern(this.namePattern), Validators.maxLength(20)]],
            username: ['', Validators.compose([Validators.required, Validators.pattern(this.emailPattern), Validators.maxLength(20)])],
            password: ['', [Validators.required, Validators.minLength(8)]],
            confirmPassword: ['', [Validators.required, Validators.minLength(8)]],
            mobile: ['', Validators.compose([Validators.required, Validators.pattern('^[0-9]*$'), Validators.minLength(10), Validators.maxLength(13)])]
        },{
          validator: ConfirmedValidator('password', 'confirmPassword')
        });
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

        this.accountService.register(this.form.value)
            .pipe(first())
            .subscribe({
                next: () => {
                    this.alertService.success('Registration successful', { keepAfterRouteChange: true });
                    this.router.navigate(['../login'], { relativeTo: this.route });
                },
                error: error => {
                    this.alertService.error(error);
                    this.loading = false;
                }
            });
    }
}
