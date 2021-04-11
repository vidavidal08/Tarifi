import {Platform} from '@ionic/angular';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalStorage } from './services/global-storage.service';


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  public showMenu: boolean = true;
  constructor(
    private platform:Platform,
    public router:Router,
    public gs: GlobalStorage
  ) {
    this.initializeApp();
  }

  initializeApp(){
  this.platform.ready().then(() => {
    // this.router.navigateByUrl('splash');
    this.gs.authentication().subscribe( item => {
      this.showMenu = !!item;
    });
  });
  }
  public logout(): void {
    this.gs.setUserLogin(null)
    .then(() => {
      this.router.navigateByUrl('login');
    });
  }
}



