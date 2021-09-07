import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PagoTarjetaPageRoutingModule } from './pago-tarjeta-routing.module';

import { PagoTarjetaPage } from './pago-tarjeta.page';

import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PagoTarjetaPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [PagoTarjetaPage]
})
export class PagoTarjetaPageModule {}
