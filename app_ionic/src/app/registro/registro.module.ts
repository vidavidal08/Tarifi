import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { RegistroPageRoutingModule } from './registro-routing.module';
import { RegistroPage } from './registro.page';
import { ModalTerminosPage } from '../modal-terminos/modal-terminos.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    RegistroPageRoutingModule,
  ],
  declarations: [RegistroPage,
                ModalTerminosPage],
  entryComponents : [ModalTerminosPage]
})
export class RegistroPageModule {}
