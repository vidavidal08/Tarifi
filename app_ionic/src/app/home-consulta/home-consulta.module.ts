import { SharedModule } from './../components/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomeConsultaPageRoutingModule } from './home-consulta-routing.module';

import { HomeConsultaPage } from './home-consulta.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomeConsultaPageRoutingModule,
    SharedModule
  ],
  declarations: [HomeConsultaPage]
})
export class HomeConsultaPageModule {}
