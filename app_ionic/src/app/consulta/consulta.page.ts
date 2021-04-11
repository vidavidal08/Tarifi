import { Component, OnInit, ViewChild } from '@angular/core';
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


  values:any=[];

  contador : number = 1;


  @ViewChild('field1') field1;
  @ViewChild('field2') field2;
  @ViewChild('field3') field3;

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


  onKeyUp(event,index){

    if(event.target.value.length === 0){
      this.setFocus(index-2);
    }
    if(event.target.name === "field1" && event.target.value.length===4){
      this.setFocus(index);
    }
    if(event.target.name === "field2" && event.target.value.length===2){
      this.setFocus(index);
    }
    if(event.target.name === "field3" && event.target.value.length===2){
      return;
    }
    else{

    }

    event.stopPropagation();

  }






  setFocus(index){

    switch(index){
      case 0:
      this.field1.setFocus();
      break;
      case 1:
      this.field2.setFocus();
      break;
      case 2:
      this.field3.setFocus();
      break;
      case 3:
      break;
      default:
        break;
      }
 }


  }



