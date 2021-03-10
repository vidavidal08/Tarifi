import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

import { GlobalStorage } from '../services/global-storage.service';

@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(
    private gs: GlobalStorage,
    public router: Router) {}
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const isAuthenticatedUser = this.gs.isAuthenticated();
    if(!isAuthenticatedUser) {
      this.router.navigate(['login']);
    }
    return isAuthenticatedUser;
  }

}
