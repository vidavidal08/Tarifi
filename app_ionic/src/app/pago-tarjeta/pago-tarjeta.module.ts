import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PagoTarjetaPageRoutingModule } from './pago-tarjeta-routing.module';

import { PagoTarjetaPage } from './pago-tarjeta.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PagoTarjetaPageRoutingModule
  ],
  declarations: [PagoTarjetaPage]
})
export class PagoTarjetaPageModule {}
