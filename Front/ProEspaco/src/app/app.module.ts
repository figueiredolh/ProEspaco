import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { NavComponent } from 'src/shared/nav/nav.component';
import { SidebarComponent } from 'src/shared/sidebar/sidebar.component';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ClienteService } from 'src/services/Cliente.service';
import { HttpClientModule } from '@angular/common/http';
import { ClientesHomeComponent } from './clientes-home/clientes-home.component';
import { ClientesCadastroComponent } from './clientes-cadastro/clientes-cadastro.component';
import { ValidationBorderDirective } from 'src/shared/validation-border-directive/validation-border.directive';
import { NgxMaskModule } from 'ngx-mask';
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    NavComponent,
    ClientesHomeComponent,
    ClientesCadastroComponent,
    ValidationBorderDirective,
   ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CollapseModule.forRoot(),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot({
      dropSpecialCharacters: false
    }),
    ModalModule.forRoot(),
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
