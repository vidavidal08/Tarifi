import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConsuldescripPageRoutingModule } from './consuldescrip-routing.module';

import { ConsuldescripPage } from './consuldescrip.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ConsuldescripPageRoutingModule
  ],
  declarations: [ConsuldescripPage]
})
export class ConsuldescripPageModule {}
