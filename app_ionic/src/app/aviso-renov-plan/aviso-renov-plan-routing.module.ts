import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AvisoRenovPlanPage } from './aviso-renov-plan.page';

const routes: Routes = [
  {
    path: '',
    component: AvisoRenovPlanPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AvisoRenovPlanPageRoutingModule {}
