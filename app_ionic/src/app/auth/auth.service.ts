import { environment } from './../../environments/environment.prod';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Login } from '../models/login';
import { GlobalStorage } from '../services/global-storage.service';
import { User } from './user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private url = environment.urlBase + 'Usuario/';
  constructor(private http: HttpClient,
    globalStorage: GlobalStorage) { }

  register(user: User) {
    return this.http.post(`${this.url}register`, user);
  }

  login(credentials: Login): Observable<string> {
    console.log(credentials);
    return this.http.post<{ token: string }>(`${this.url}login`, credentials).pipe(
      map(response => response.token));
  }
}
