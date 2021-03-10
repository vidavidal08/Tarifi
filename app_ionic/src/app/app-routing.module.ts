import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then( m => m.HomePageModule)
  },
 /* {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },*/
  {
    path: 'splash',
    loadChildren: () => import('./splash-screen/splash-screen.module').then( m => m.SplashScreenPageModule)
  },
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
    loadChildren: () => import('./consulta/consulta.module').then( m => m.ConsultaPageModule)
  },
  {
    path: 'list-nico',
    loadChildren: () => import('./list-nico/list-nico.module').then( m => m.ListNicoPageModule)
  },
  {
    path: 'detalle-nico',
    loadChildren: () => import('./detalle-nico/detalle-nico.module').then( m => m.DetalleNicoPageModule)
  },
  {
    path: 'editar-perfil',
    loadChildren: () => import('./editar-perfil/editar-perfil.module').then( m => m.EditarPerfilPageModule)
  },
  {
    path: 'consuldescrip',
    loadChildren: () => import('./consuldescrip/consuldescrip.module').then( m => m.ConsuldescripPageModule)
  },
  {
    path: 'home-consulta',
    loadChildren: () => import('./home-consulta/home-consulta.module').then( m => m.HomeConsultaPageModule)
  },
  {
    path: 'registro-exitoso',
    loadChildren: () => import('./registro-exitoso/registro-exitoso.module').then( m => m.RegistroExitosoPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
