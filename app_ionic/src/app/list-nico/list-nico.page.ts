import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Fraccion } from '../models/fraccion';
import { ApiSwaggerService } from '../services/api-swagger.service';

@Component({
  selector: 'app-list-nico',
  templateUrl: './list-nico.page.html',
  styleUrls: ['./list-nico.page.scss'],
})
export class ListNicoPage implements OnInit {
  public fracciones: Array<Fraccion> = new Array<Fraccion>();

  constructor(
    private route: ActivatedRoute,
    private apiSwaggerService: ApiSwaggerService
  ) { }

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    let clave = routeParams.get('clave');
    clave = clave === '..' ? '' : clave;

    this.apiSwaggerService.getFraccionesNicos().then( data => {
      console.log(data);
      this.fracciones = data.filter( (item) => item.claveFraccion.includes(clave)).sort();
    });
  }
}
