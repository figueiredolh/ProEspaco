import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

/* @Injectable({
  providedIn: 'root'
}) */

@Injectable()
export class CepService {

  constructor(private client: HttpClient) { }

  public getCep(cep: string): Observable<any>{
    let baseUrl: string = `https://viacep.com.br/ws/${cep}/json/`;
    return this.client.get<any>(baseUrl);
  }

}
