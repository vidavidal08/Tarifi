import { Fraccion } from './../models/fraccion';
import { Component, OnInit,Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GlobalStorage } from '../services/global-storage.service';

@Component({
  selector: 'app-detalle-nico',
  templateUrl: './detalle-nico.page.html',
  styleUrls: ['./detalle-nico.page.scss'],
})
export class DetalleNicoPage implements OnInit {
  @Input () anteriorNICOClave;
  @Input () anteriorNICODescri;
   descripcionNICO = "prueba";

  public fraccion: Fraccion = {
    id: '',
    claveFraccion:'',
    descripcion: '',
    unidadMedida:	'',
    igi: '',
    ige: '',
    nicos: [],

  };

  
  constructor(
    private gs: GlobalStorage,
    private route: ActivatedRoute) { }

  ngOnInit() {
    const routeParams = this.route.snapshot.paramMap;
    const id = routeParams.get('id');
    this.gs.getFracciones()
    .then(fracciones => {
      this.fraccion = fracciones.find( item => item.id === id);
      this.gs.setSelectedNicoCounter(this.fraccion);
      console.log(this.fraccion);
    });
  }



}
