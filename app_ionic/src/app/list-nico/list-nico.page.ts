import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Fraccion } from '../models/fraccion';
import { ApiSwaggerService } from '../services/api-swagger.service';
import { GlobalStorage } from '../services/global-storage.service';

@Component({
  selector: 'app-list-nico',
  templateUrl: './list-nico.page.html',
  styleUrls: ['./list-nico.page.scss'],
})
export class ListNicoPage implements OnInit {
  padreClaveNICO ="";
  padreDescripNICO="";

  public fracciones: Array<Fraccion> = new Array<Fraccion>();
  public tipoBusqueda = '';
  constructor(
    private route: ActivatedRoute,
    private apiSwaggerService: ApiSwaggerService,
    private gs: GlobalStorage
  ) { }

  ngOnInit() {}

  pasarVariables(clave:string, descripcNICO:string){
    this.padreClaveNICO = clave;
    this.padreDescripNICO = descripcNICO;
    console.log(clave,descripcNICO );
    }


    ionViewWillEnter() {

      const routeParams = this.route.snapshot.paramMap;
      this.tipoBusqueda = routeParams.get('tipobusqueda');
      let clave = routeParams.get('clave');
      clave = clave === ' ' ? '' : clave;

      if(this.tipoBusqueda === 'top10') {
        this.fracciones = this.gs.getSelectedNicoCounter().sort( (a,b) => {
          if( a['counter'] > b['counter']) {
            return 1;
          } else if(a['counter'] < b['counter']) {
            return -1;
          } else {
            return 0;
          }
        }).slice(0,10);
        this.gs.setFracciones(this.fracciones);
      } else {

        if(this.tipoBusqueda === 'clave'){
          this.apiSwaggerService.getFraccionesNicoFiltradas(clave, '').then(data => {
            this.fracciones = data;
            this.gs.setFracciones(this.fracciones);
          });
        } else {
          this.apiSwaggerService.getFraccionesNicoFiltradas('', clave).then(data => {
            this.fracciones = data;
            this.gs.setFracciones(this.fracciones);
          });
        }

        /// <---
        // this.gs.getFraccionesCache().then( data => {
        //   if(this.tipoBusqueda === 'clave') {
        //     this.fracciones = data.some( (item) =>item.claveFraccion &&  item.claveFraccion.includes(clave))
        //     ? data.filter( (item) => item.claveFraccion  &&  item.claveFraccion.includes(clave)).sort().slice(0,100)
        //     : new Array<Fraccion>();
        //   }
        //   else if(this.tipoBusqueda === 'descripcion'){
        //     this.fracciones = data.filter( (item) => item.descripcion && item.descripcion.toUpperCase().includes(clave.toUpperCase())).sort().slice(0,100);
        //   }
        //   this.gs.setFracciones(this.fracciones);
        // });

        /// --->
      }
    }
}
