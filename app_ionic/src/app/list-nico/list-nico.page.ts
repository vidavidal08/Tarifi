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

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    const tipobusqueda = routeParams.get('tipobusqueda');
    let clave = routeParams.get('clave');
    clave = clave === '..' ? '' : clave;
    this.apiSwaggerService.getFraccionesNicos().then( data => {
      if(tipobusqueda === 'clave') {
        this.fracciones = data.filter( (item) => item.claveFraccion.includes(clave)).sort();
      }
      else {
        this.fracciones = data.filter( (item) => item.descripcion && item.descripcion.includes(clave)).sort();
      }
      this.gs.setFracciones(this.fracciones);
    });
  }
}
