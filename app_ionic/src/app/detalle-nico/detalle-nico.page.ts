import { Fraccion } from './../models/fraccion';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GlobalStorage } from '../services/global-storage.service';

@Component({
  selector: 'app-detalle-nico',
  templateUrl: './detalle-nico.page.html',
  styleUrls: ['./detalle-nico.page.scss'],
})
export class DetalleNicoPage implements OnInit {
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

  public selectedPF: {
    id: string,
    permiso: string,
    acotacion: string
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
    const claveNICO = routeParams.get('claveNico');
    this.gs.getFracciones()
      .then(fracciones => {
        this.fraccion = fracciones.find(item => item.id === id);
        this.selectedNico.claveNICO = this.fraccion.nicos.find(x => x['claveNICO'] === claveNICO)['claveNICO'];
        this.selectedNico.descripcion = this.fraccion.nicos.find(x => x['claveNICO'] === claveNICO)['descripcion'];
        this.selectedPF.id = this.fraccion.permisosFraccion.find(x => x['claveNICO'] === claveNICO)['id'];
        this.gs.setSelectedNicoCounter(this.fraccion);
        console.log(this.fraccion);
        console.log(this.selectedNico);
        console.log(this.selectedPF);

      });
  }
}
