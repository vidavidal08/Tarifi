import { Component, OnInit } from '@angular/core';
import { ApiSwaggerService } from '../services/api-swagger.service';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.page.html',
  styleUrls: ['./consulta.page.scss'],
})
export class ConsultaPage implements OnInit {
  public parte1: string = '';
  public parte2: string = '';
  public parte3: string = '';

  constructor() {}

  ngOnInit() {}


  public get clave(): string {

    if (this.parte1 !== '' && this.parte2 === '' && this.parte3 === '') {
      return this.parte1;
    } else if (this.parte1 !== '' && this.parte2 !== '' && this.parte3 === '') {
      return this.parte1 + '.' + this.parte2;
    } else if (this.parte1 !== '' && this.parte2 !== '' && this.parte3 !== '') {
      return this.parte1 + '.' + this.parte2 + '.' + this.parte3;
    } else if (this.parte1 === '' && this.parte2 === '' && this.parte3 === '') {
      return ' ';
    } else {
      return ' ';
    }

  }
}
