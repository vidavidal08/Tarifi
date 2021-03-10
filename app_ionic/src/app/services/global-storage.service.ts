import { catalogs } from './../models/constants';
import { Injectable } from '@angular/core';

import { authentication } from '../models/constants';
import { Fraccion } from '../models/fraccion';
import { Login } from '../models/login';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalStorage {
  private currentUser = new BehaviorSubject<Login>(null);

  public setData(data: any, key: string): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      localStorage.setItem(key, JSON.stringify(data));
      resolve();
    });
  }
  public getData<T>(key: string): Promise<T> {
    return new Promise<T>((resolve, reject) => {
      let itemStrginValue = localStorage.getItem(key);
      const itemToReturn = JSON.parse(itemStrginValue) as T;
      resolve(itemToReturn);
    });
  }
  public setUserLogin(login: Login): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      this.setData(login, authentication.loginStorageKey);
      this.currentUser.next(login);
      resolve();
    });
  }
  public getCurrentUser(): Promise<Login> {
    return new Promise<Login>((resolve, reject) => {
      let itemStrginValue = localStorage.getItem(authentication.loginStorageKey);
      const itemToReturn = JSON.parse(itemStrginValue) as Login;
      resolve(itemToReturn);
    });
  }
  public getCurrentUserNoPromise(): Login {
    let itemStrginValue = localStorage.getItem(authentication.loginStorageKey);
    const itemToReturn = JSON.parse(itemStrginValue) as Login;
    return itemToReturn;
  }
  public isAuthenticated(): boolean {
    const currentuser = this.getCurrentUserNoPromise();
    return !!currentuser;
  }
  public setFracciones(fracciones: Array<Fraccion>): void {
    this.setData(fracciones, catalogs.fracciones);
  }
  public getFracciones(): Promise<Array<Fraccion>> {
    return this.getData<Array<Fraccion>>(catalogs.fracciones);
  }
  public authentication(): Observable<Login> {
    return this.currentUser.asObservable();
  }
}
