import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from 'src/models/Cliente';

/* @Injectable({
  providedIn: 'root'
}); */

@Injectable()
export class ClienteService {

  constructor(private client: HttpClient) { }

  public baseUrl: string = "https://localhost:5001/api";

  public getClientes(): Observable<Cliente[]>{
    return this.client.get<Cliente[]>(`${this.baseUrl}/clientes`);
  }

  public deleteCliente(id: number){
    return this.client.delete(`${this.baseUrl}/clientes/${id}`);
  }

}
