import { Fraccion, PermisosFraccion } from './../models/fraccion';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GlobalStorage } from '../services/global-storage.service';

@Component({
  selector: 'app-detalle-nico',
  templateUrl: './detalle-nico.page.html',
  styleUrls: ['./detalle-nico.page.scss'],
})
export class DetalleNicoPage implements OnInit {
  public permisos: PermisosFraccion[] = [];
  public _id : string = '';
  

  public fraccion: Fraccion = {
    id: '',
    claveFraccion: '',
    descripcion: '',
    unidadMedida: '',
    igi: '',
    ige: '',
    permisosFraccion:[],
    nicos: [],
  };

  public selectedNico: {
    claveNICO: string,
    descripcion: string
  };

  constructor(
    private gs: GlobalStorage,
    private route: ActivatedRoute) { }

    ngOnInit(): void {
      this.selectedNico = {
        claveNICO: '',
        descripcion: ''
      };
  }

  ionViewWillEnter() {
    this.selectedNico = {
      claveNICO: '',
      descripcion: ''
    };
    const routeParams = this.route.snapshot.paramMap;
    const id = routeParams.get('id');
    this._id = id;
    
    const claveNICO = routeParams.get('claveNico');
    this.gs.getFracciones()
      .then(fracciones => {
        this.fraccion = fracciones.find(item => item.id === id);
        this.selectedNico.claveNICO = this.fraccion.nicos.find(x => x['claveNICO'] === claveNICO)['claveNICO'];
        this.selectedNico.descripcion = this.fraccion.nicos.find(x => x['claveNICO'] === claveNICO)['descripcion'];
        this.permisos = this.fraccion.permisosFraccion;
        this.gs.setSelectedNicoCounter(this.fraccion);
      });
  }
}
