import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DetalleNicoPageRoutingModule } from './detalle-nico-routing.module';

import { DetalleNicoPage } from './detalle-nico.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DetalleNicoPageRoutingModule
  ],
  declarations: [DetalleNicoPage]
})
export class DetalleNicoPageModule {}
