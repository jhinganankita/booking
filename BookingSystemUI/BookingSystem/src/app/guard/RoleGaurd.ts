import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const userRole = localStorage.getItem('userRole'); // Retrieve the user's role from storage
    const allowedRoles = childRoute.data['allowedRoles'] as string[]; // Get the allowed roles from the child route's data

    if (userRole !== null && allowedRoles && allowedRoles.includes(userRole)) {
        return true; // User has the required role, allow access
      }

    // User does not have the required role, redirect to a different page or show an error message
    this.router.navigate(['/access-denied']);
    return false;
  } 
}
