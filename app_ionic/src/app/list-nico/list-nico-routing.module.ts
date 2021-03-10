import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ListNicoPage } from './list-nico.page';

const routes: Routes = [
  {
    path: '',
    component: ListNicoPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ListNicoPageRoutingModule {}
