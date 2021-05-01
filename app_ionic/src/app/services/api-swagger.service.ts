import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Fraccion } from '../models/fraccion';

import { Registro } from '../models/registro.model';
import { ResponseRegistro } from '../models/response-registro-model';

@Injectable({
  providedIn: 'root'
})
export class ApiSwaggerService {
  private url = environment.urlBase;

  constructor(private http: HttpClient) {}

   private headers =  {
    headers: new  HttpHeaders({
      'Content-Type': 'application/json'})
  };

  register(registro: Registro): Observable<ResponseRegistro[]>{
    return this.http.post<ResponseRegistro[]>(`${this.url}/usuario/registrar`,registro);
   /* return this.http.post(`${this.url}/usuario/registrar`, registro).pipe(
      map(results => {

        return Response;
      }),
      catchError(error => {
        //  return console.log(err);
        console.log("ENTRA AL ERROR" +error[0]);
        return null;
      })
    );*/
  }
  public getFraccionesNicos(): Promise<Array<Fraccion>> {
    return this.http.get<Array<Fraccion>>(this.url+'Fraccion',{}).toPromise();
  }
  public getFraccionesNicoFiltradas(claveArancelaria: string, descripcion: string): Promise<Array<Fraccion>> {
    return this.http.get<Array<Fraccion>>(this.url+'Fraccion/filtro', {
      params: { 
        'ClaveArancelaria': claveArancelaria, 
        'Descripcion': descripcion
      }
    }).toPromise();
  }
}
