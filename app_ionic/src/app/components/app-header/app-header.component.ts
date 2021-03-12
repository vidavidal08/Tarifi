import { Login } from './../../models/login';
import { Component, OnInit } from '@angular/core';
import { GlobalStorage } from "src/app/services/global-storage.service";

@Component({
  selector: 'app-header',
  templateUrl: 'app-header.component.html',
  styleUrls: ['app-header.component.scss'],
})
export class AppHeader implements OnInit {
  public usuario: Login = {
    email: '',
    nombre: '',
    password: '',
    token: ''
    };

  constructor(private gs: GlobalStorage) {}
  ngOnInit(): void {
    this.gs.getCurrentUser()
    .then( item => {
      this.usuario = item;
    });
  }

}
