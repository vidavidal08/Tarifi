import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PagoTarjetaPage } from './pago-tarjeta.page';

const routes: Routes = [
  {
    path: '',
    component: PagoTarjetaPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagoTarjetaPageRoutingModule {}
