import { Component, OnInit } from '@angular/core';
import { AlertController, ModalController } from '@ionic/angular';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';



@Component({
  selector: 'app-pago-tarjeta',
  templateUrl: './pago-tarjeta.page.html',
  styleUrls: ['./pago-tarjeta.page.scss'],
})
export class PagoTarjetaPage implements OnInit {

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
    public modalController: ModalController
  ) { }



  ngOnInit(): void {

    this.form = new FormGroup({
      nombre_titular: new FormControl('', [
        Validators.required
      ])
    });
  }

  async onSubmit() {
  }

}
