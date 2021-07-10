import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PermisosFraccion } from './../models/fraccion';
import { GlobalStorage } from '../services/global-storage.service';

@Component({
  selector: 'app-permisos',
  templateUrl: './permisos.page.html',
  styleUrls: ['./permisos.page.scss'],
})
export class PermisosPage implements OnInit {
  public permisos: PermisosFraccion[] = [];

  constructor(
    private gs: GlobalStorage,
    private route: ActivatedRoute) { }

  ngOnInit() {

    this.gs.getFracciones()
    .then(fracciones => {

      const routeParams = this.route.snapshot.paramMap;
      const id = routeParams.get('id');

      const fraccion = fracciones.find(item => item.id === id);
      this.permisos = fraccion.permisosFraccion
      console.log(this.permisos);

    });

  }
}
