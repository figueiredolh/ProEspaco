import { Component, Input, OnInit } from '@angular/core';
import { ClientesHomeComponent } from 'src/app/clientes-home/clientes-home.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor() { }

  @Input() page: string = "Página";

  ngOnInit() {
  }

}
