import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Registro } from '../models/registro.model';
import { ResponseRegistro } from '../models/response-registro-model';

@Injectable({
  providedIn: 'root'
})
export class ApiSwaggerService {

  private url = 'https://nicosappapi20210227004145.azurewebsites.net/api';

  constructor(private http: HttpClient) {
  
   }

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
}
