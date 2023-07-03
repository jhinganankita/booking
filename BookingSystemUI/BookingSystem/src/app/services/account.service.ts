import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from './../environments/environment';
import { IUser } from '../models/IUser';
import { Role } from '../models/Role';

@Injectable({ providedIn: 'root' })
export class AccountService {
    private userSubject: BehaviorSubject<IUser | null>;
    public user: Observable<IUser | null>;
    baseURL= environment.baseUrl;
    private userRole: string = '';

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('user')!));
        this.user = this.userSubject.asObservable();
    }

    public get userValue() {
        return this.userSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<IUser>(`${this.baseURL}users/authenticate`, { username, password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this.userSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['/account/login']);
    }

    register(user: IUser) {
        user.roleName = Role.User;
        return this.http.post(`${this.baseURL}users`, user);
    }

    getAll() {
        return this.http.get<IUser[]>(`${this.baseURL}users`);
    }

    getById(id: string) {
        return this.http.get<IUser>(`${this.baseURL}users/${id}`);
    }
}
