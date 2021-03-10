import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { LoadingController, AlertController } from '@ionic/angular';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ConsultaPage } from '../consulta/consulta.page';
import { ThisReceiver } from '@angular/compiler';

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
   // private authService: AuthService,
    private alertController: AlertController,
    private alertCtrl: AlertController,
    private loadingCtrl: LoadingController,
    private router: Router,
    private formBuilder: FormBuilder
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


  /*  const loading = await this.loadingCtrl.create({ message: 'Logging in ...' });
    await loading.present();
   
    this.authService.login(this.form.value).subscribe(
      async token => {
        localStorage.setItem('token', token);
        loading.dismiss();
        this.router.navigateByUrl('/create');
      },
      async () => {
        const alert = await this.alertCtrl.create({ message: 'Login Failed', buttons: ['OK'] });
        await alert.present();
        loading.dismiss();
      }
    );*/
  }

}
