import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConsuldescripPage } from './consuldescrip.page';

const routes: Routes = [
  {
    path: '',
    component: ConsuldescripPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConsuldescripPageRoutingModule {}
