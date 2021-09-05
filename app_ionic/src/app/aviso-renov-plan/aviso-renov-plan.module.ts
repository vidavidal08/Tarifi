import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AvisoRenovPlanPageRoutingModule } from './aviso-renov-plan-routing.module';

import { AvisoRenovPlanPage } from './aviso-renov-plan.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AvisoRenovPlanPageRoutingModule
  ],
  declarations: [AvisoRenovPlanPage]
})
export class AvisoRenovPlanPageModule {}
