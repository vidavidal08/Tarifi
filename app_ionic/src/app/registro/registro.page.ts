import { Component, OnInit } from '@angular/core';
import { AlertController, ModalController } from '@ionic/angular';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiSwaggerService } from './../services/api-swagger.service'
import { Registro } from '../models/registro.model';
import { ModalTerminosPage } from '../modal-terminos/modal-terminos.page';



@Component({
  selector: 'app-registro',
  templateUrl: './registro.page.html',
  styleUrls: ['./registro.page.scss'],
})
export class RegistroPage implements OnInit {

  form: FormGroup;
  loading = false;
  submitted = true;
  validacionContra: boolean;
  validacionCorreo: boolean;
  information = null;
  ok: boolean;
  error: string;
  mensaje: string;

  constructor(
    private alertController: AlertController,
    private router: Router,
    private serviceApis: ApiSwaggerService,
    public modalController: ModalController
  ) { }

  ngOnInit(): void {

    this.form = new FormGroup({
      nombre: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      apellidos: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      correo: new FormControl('', [
        Validators.required,
        Validators.minLength(4),
      ]),
      contra1: new FormControl('', [
        Validators.required

      ]),
      contra2: new FormControl('', [
        Validators.required]
      ),
      terminos: new FormControl(false, [
        Validators.requiredTrue]
      ),
    });


  }

  tagContra() {
    this.validacionContra = true;
  }

  tagCorreo() {
    this.validacionCorreo = true;
  }

  async modalTerminos(){
    
    const modal = await this.modalController.create({
      component: ModalTerminosPage,
      cssClass: 'my-custom-class'
    });
    return await modal.present();
  }


  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }


  async RespuestaBack_Bag(mensaje: string) {

    const alert = await this.alertController.create({
      backdropDismiss: false,
      message: mensaje,
      buttons: [
        {
          text: 'OK',
          handler: () => {
            console.log('Buy clicked');
            this.form.reset();
          }
        }
      ]
    });

    await alert.present();

  }

  async RespuestaBack_OK() {


    const alert = await this.alertController.create({
      backdropDismiss: false,
      message: 'Correo registrado exitosamente',
      buttons: [
        {
          text: 'OK',
          handler: () => {
            console.log('Buy clicked');
            //window.location.reload();
            this.router.navigate(['/login']);
          }
        }
      ]
    });

    await alert.present();

  }



  private getAddNewRegistro(): Registro {
    return {
      nombre: this.form.controls.nombre.value,
      apellidos: this.form.controls.apellidos.value,
      email: this.form.controls.correo.value,
      password: this.form.controls.contra1.value
    }
  }

  async onSubmit() {
    debugger;
    let correoValor: boolean;
    let contrasenaValor: boolean;
    let regexp = new RegExp('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$');

    if (regexp.exec(this.f.correo.value)) {
      correoValor = true;
      //Correo bien 
      console.log(this.f.correo.value);
    } else {
      //Correo mal
      this.validacionCorreo = false;
    }

    if (this.f.contra1.value == this.f.contra2.value) {
      contrasenaValor = true;
    } else {
      this.validacionContra = false;
      console.log("las contraseñas no coinciden ");
    }
    // Condicional para manddar datos a End Point
    if (correoValor == true && contrasenaValor == true) {

      this.serviceApis.register(this.getAddNewRegistro()).subscribe(result => {
       /* console.log(result);
        console.log(this.error = result["errores"]);
        console.log(this.ok = result["isOk"]);
        console.log(this.mensaje = result["mensaje"]);*/

        if (this.ok) {
          console.log("USUARIO REGISTRADO");
          this.RespuestaBack_OK();
        } else if (!this.ok) {

          this.RespuestaBack_Bag(this.mensaje);
        }
      });
    }
  }
}


