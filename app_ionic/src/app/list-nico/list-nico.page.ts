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
  public fracciones: Array<Fraccion> = new Array<Fraccion>();

  constructor(
    private route: ActivatedRoute,
    private apiSwaggerService: ApiSwaggerService,
    private gs: GlobalStorage
  ) { }

  ngOnInit() {}
  ionViewWillEnter() {
    const routeParams = this.route.snapshot.paramMap;
    const tipobusqueda = routeParams.get('tipobusqueda');
    let clave = routeParams.get('clave');
    clave = clave === '..' ? '' : clave;
    if(tipobusqueda === 'top10') {
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
      this.apiSwaggerService.getFraccionesNicos().then( data => {
      this.gs.getFraccionesCache().then( data => {
        if(tipobusqueda === 'clave') {
          this.fracciones = data.filter( (item) => item.claveFraccion.includes(clave)).sort();
          this.fracciones = data.filter( (item) => item.claveFraccion.includes(clave)).sort().slice(0,100);
        }
        else if(tipobusqueda === 'descripcion'){
          this.fracciones = data.filter( (item) => item.descripcion && item.descripcion.toUpperCase().includes(clave.toUpperCase())).sort();
          this.fracciones = data.filter( (item) => item.descripcion && item.descripcion.toUpperCase().includes(clave.toUpperCase())).sort().slice(0,100);
        }
        this.gs.setFracciones(this.fracciones);
      });
    }
  }
}
