import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './auth/authguard.service';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then( m => m.HomePageModule),
    canActivate: [AuthGuardService]
  },
 {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  /*{
    path: 'splash',
    loadChildren: () => import('./splash-screen/splash-screen.module').then( m => m.SplashScreenPageModule)
  },*/
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'registro',
    loadChildren: () => import('./registro/registro.module').then( m => m.RegistroPageModule)
  },
  {
    path: 'consulta',
    loadChildren: () => import('./consulta/consulta.module').then( m => m.ConsultaPageModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'list-nico/:tipobusqueda/:clave',
    loadChildren: () => import('./list-nico/list-nico.module').then( m => m.ListNicoPageModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'detalle-nico/:id/:claveNico',
    loadChildren: () => import('./detalle-nico/detalle-nico.module').then( m => m.DetalleNicoPageModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'editar-perfil',
    loadChildren: () => import('./editar-perfil/editar-perfil.module').then( m => m.EditarPerfilPageModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'consuldescrip',
    loadChildren: () => import('./consuldescrip/consuldescrip.module').then( m => m.ConsuldescripPageModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'home-consulta',
    loadChildren: () => import('./home-consulta/home-consulta.module').then( m => m.HomeConsultaPageModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'registro-exitoso',
    loadChildren: () => import('./registro-exitoso/registro-exitoso.module').then( m => m.RegistroExitosoPageModule)
  },
  {
    path: 'modal-terminos',
    loadChildren: () => import('./modal-terminos/modal-terminos.module').then( m => m.ModalTerminosPageModule)
  },
  {
    path: 'permisos/:id',
    loadChildren: () => import('./permisos/permisos.module').then( m => m.PermisosPageModule),
    canActivate: [AuthGuardService]

  },
  {
    path: 'aviso-renov-plan',
    loadChildren: () => import('./aviso-renov-plan/aviso-renov-plan.module').then( m => m.AvisoRenovPlanPageModule)
  },
  {
    path: 'pago-tarjeta',
    loadChildren: () => import('./pago-tarjeta/pago-tarjeta.module').then( m => m.PagoTarjetaPageModule)
  },

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
