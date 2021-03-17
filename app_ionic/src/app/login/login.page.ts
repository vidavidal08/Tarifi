import { ApiSwaggerService } from './../services/api-swagger.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertController, LoadingController } from '@ionic/angular';

import { AuthService } from '../auth/auth.service';
import { Login } from '../models/login';
import { GlobalStorage } from '../services/global-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage  implements OnInit{

  form: FormGroup;
  loading = false;
  submitted = false;


  constructor(
    private authService: AuthService,
    private alertController: AlertController,
    private alertCtrl: AlertController,
    private loadingCtrl: LoadingController,
    private router: Router,
    private formBuilder: FormBuilder,
    private apiSwaggerService: ApiSwaggerService,
    private globalStorage: GlobalStorage
  ) { }


  get f() { return this.form.controls; }

  ngOnInit(): void {
    if(this.globalStorage.isAuthenticated()) {
      console.log('authenticated');
      this.router.navigateByUrl('/home');
      return;
    };
     //this.form.reset();

    this.form = new FormGroup({
      username: new FormControl('', [
        Validators.required,
        Validators.minLength(5),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(5),
      ]),
    });
    // Para propositos meramente de desarrollo
    // comentar las siguientes lineas cuando no se estè desarrollando
    this.form.controls.username.setValue('rafael.ceballos@xibalbalabs.com');
    this.form.controls.password.setValue('123456');


    this.apiSwaggerService.getFraccionesNicos()
    .then( data => {
      console.log(data);
      this.globalStorage.setFraccionesCache(data);
    });

  }

  // convenience getter for easy access to form fields


  async RespuestaBack(){


    const alert = await this.alertController.create({
     cssClass: 'my-custom-class',
     header: 'Acceso denegado',
     subHeader: 'Usuario o contraseña incorrecta',
     message: 'Intente nuevamente',
     buttons: ['OK']
   });

   await alert.present();

}

 async onSubmit() {

  console.log(this.f.username.value,this.f.password.value);

  //this.RespuestaBack();
   //console.log(this.form.value);
   const loading = await this.loadingCtrl.create({ message: 'Logging in ...' });
   await loading.present();
   const userToIn: Login = {
    email: this.f.username.value,
    nombre: '',
    password: this.f.password.value,
    token: ''
    };
    this.authService.login(userToIn).subscribe(
      async token => {
        const userLogedIn: Login = {
          email: this.f.username.value,
          nombre: token.nombre,
          password: this.f.password.value,
          token: token.token
        };
        this.globalStorage.setUserLogin(userLogedIn).then();
        loading.dismiss();
        this.router.navigateByUrl('/home');
      },
      async () => {
        const alert = await this.alertCtrl.create({ message: 'Credenciales inválidas', buttons: ['OK'] });
        await alert.present();
        loading.dismiss();
      }
    );
  }

}
