import { Injectable } from '@angular/core';

import { authentication } from '../models/constants';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class  GlobalStorage {
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
      return new Promise<void>( (resolve, reject) => {
        this.setData(login, authentication.loginStorageKey);
        resolve();
      });
    }
    public getCurrentUser(): Promise<Login> {
      return new Promise<Login>( (resolve, reject) => {
        let itemStrginValue = localStorage.getItem(authentication.loginStorageKey);
        const itemToReturn = JSON.parse(itemStrginValue) as Login;
        resolve(itemToReturn);
      });
    }

}
