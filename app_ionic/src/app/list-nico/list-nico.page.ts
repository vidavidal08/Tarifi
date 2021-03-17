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
  public tipoBusqueda = '';
  constructor(
    private route: ActivatedRoute,
    private apiSwaggerService: ApiSwaggerService,
    private gs: GlobalStorage
  ) { }

  ngOnInit() {}
  ionViewWillEnter() {
    const routeParams = this.route.snapshot.paramMap;
    this.tipoBusqueda = routeParams.get('tipobusqueda');
    let clave = routeParams.get('clave');
    clave = clave === '..' ? '' : clave;
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
      this.gs.getFraccionesCache().then( data => {
        if(this.tipoBusqueda === 'clave') {
          this.fracciones = data.some( (item) => item.claveFraccion === clave)
          ? data.filter( (item) => item.claveFraccion === clave).sort().slice(0,100)
          : new Array<Fraccion>();
        }
        else if(this.tipoBusqueda === 'descripcion'){
          this.fracciones = data.filter( (item) => item.descripcion && item.descripcion.toUpperCase().includes(clave.toUpperCase())).sort().slice(0,100);
        }
        this.gs.setFracciones(this.fracciones);
      });
    }
  }
}
