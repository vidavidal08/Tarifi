import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { SharedModule } from '../components/shared.module';
import { PermisosPageRoutingModule } from './permisos-routing.module';
import { PermisosPage } from './permisos.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PermisosPageRoutingModule,
    SharedModule
  ],
  declarations: [PermisosPage]
})
export class PermisosPageModule {}
