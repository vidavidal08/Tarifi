import { User } from './../auth/user.model';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { LoadingController, AlertController } from '@ionic/angular';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ConsultaPage } from '../consulta/consulta.page';
import { ThisReceiver } from '@angular/compiler';
import { GlobalStorage } from '../services/global-storage.service';
import { Login } from '../models/login';

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
    private globalStorage: GlobalStorage
  ) { }


  get f() { return this.form.controls; }

  ngOnInit(): void {
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
    // this.form.controls.username.setValue('rafael.ceballos@xibalbalabs.com');
    // this.form.controls.password.setValue('tipo1234');
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
    password: this.f.password.value,
    token: ''
    };
    this.authService.login(userToIn).subscribe(
      async token => {
        const userLogedIn: Login = {
          email: this.f.username.value,
          password: this.f.password.value,
          token: token
        };
        this.globalStorage.setUserLogin(userLogedIn).then();
        loading.dismiss();
        this.router.navigateByUrl('/home');
      },
      async () => {
        const alert = await this.alertCtrl.create({ message: 'Login Failed', buttons: ['OK'] });
        await alert.present();
        loading.dismiss();
      }
    );
  }

}