import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesCadastroComponent } from './clientes-cadastro/clientes-cadastro.component';
import { ClientesHomeComponent } from './clientes-home/clientes-home.component';

const routes: Routes = [
  {path: '', redirectTo: 'clientes', pathMatch: 'full' },
  {path: 'clientes', component: ClientesHomeComponent},
  {path: 'clientes/cadastro', component: ClientesCadastroComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
