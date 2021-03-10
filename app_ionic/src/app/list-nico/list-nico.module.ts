import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ListNicoPageRoutingModule } from './list-nico-routing.module';

import { ListNicoPage } from './list-nico.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ListNicoPageRoutingModule
  ],
  declarations: [ListNicoPage]
})
export class ListNicoPageModule {}
