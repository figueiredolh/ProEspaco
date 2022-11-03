import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { Cliente } from 'src/models/Cliente';
import { ClienteService } from 'src/services/Cliente.service';

@Component({
  selector: 'app-clientes-lista',
  templateUrl: './clientes-lista.component.html',
  styleUrls: ['./clientes-lista.component.css']
})
export class ClientesListaComponent implements OnInit {

  constructor(private clienteService: ClienteService) { }

  @ViewChildren('listItem')
  public listItems!: QueryList<ElementRef<HTMLDivElement>>

  public ngAfterViewInit() {
  }

  titulo: string = 'Ver Detalhes';
  public clientes: Cliente[] = [];

  expandMenu(index: number): void{
    let currentItem = this.listItems.get(index)?.nativeElement;

    if(this.listItems.length > 1){
      this.listItems.forEach(item => {
        if(item.nativeElement != currentItem){
          item.nativeElement.classList.add('collapsed');
        }
      });
    }

    currentItem?.classList.toggle('collapsed');
  }

  getClientes(): void{
    this.clienteService.getClientes().subscribe({
      next: (clientes: Cliente[]) => {
        this.clientes = [... clientes];
      },
      error: (error) => {
        console.log(error);
      },
      complete: () => {
        console.log("Carregado");
        console.log(this.clientes);
      }
    });
  }

  ngOnInit() {
    this.getClientes();
  }

}
