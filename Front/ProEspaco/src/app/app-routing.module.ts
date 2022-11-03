import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesListaComponent } from './clientes/clientes-lista/clientes-lista.component';
import { ClientesComponent } from './clientes/clientes.component';

const routes: Routes = [
  {
    path: 'clientes', component: ClientesListaComponent,
  },
  {
    path: '**', redirectTo: 'clientes', pathMatch: 'full' //teste
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
