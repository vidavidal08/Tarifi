import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { authentication } from '../models/constants';
import { Fraccion } from '../models/fraccion';
import { Login } from '../models/login';
import { catalogs } from './../models/constants';

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
      const itemToReturn = this.getDataSync<T>(key);
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
      const itemToReturn = this.getDataSync<Login>(authentication.loginStorageKey);
      resolve(itemToReturn);
    });
  }
  public getCurrentUserNoPromise(): Login {
    const itemToReturn = this.getDataSync<Login>(authentication.loginStorageKey);
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
  public setSelectedNicoCounter(fraccion: Fraccion) {
    this.getData<Array<Fraccion>>(catalogs.nicosCounter)
    .then(items => {
      const existsItem = !!items &&  !!items.find( x=> x.id === fraccion.id);
      if (existsItem) {
        const existingFraccionIndex = items.findIndex( x=> x.id === fraccion.id);
        items[existingFraccionIndex]['counter']++;
        this.setData(items,catalogs.nicosCounter);
      } else {
        fraccion['counter'] = 1;
        items = !!items ? items : new Array<Fraccion>();
        items.push(fraccion);
        this.setData(items,catalogs.nicosCounter);
      }
    });
  }
  public getSelectedNicoCounter(): Array<Fraccion> {
    let fracciones = this.getDataSync<Array<Fraccion>>(catalogs.nicosCounter);
    fracciones = !!fracciones ? fracciones : new Array<Fraccion>();
    return fracciones;
  }
  public getDataSync<T>(key: string) {
    let itemStrginValue = localStorage.getItem(key);
    const itemToReturn = JSON.parse(itemStrginValue) as T;
    return itemToReturn;
  }
}
