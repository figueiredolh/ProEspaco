import { Component, ElementRef, EventEmitter, OnInit, Output, QueryList, TemplateRef, ViewChildren } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cliente } from 'src/models/Cliente';
import { ClienteService } from 'src/services/Cliente.service';

@Component({
  selector: 'app-clientes-home2-home',
  templateUrl: './clientes-home.component.html',
  styleUrls: ['./clientes-home.component.css']
})
export class ClientesHomeComponent implements OnInit {

  constructor(private clienteService: ClienteService, private modalService: BsModalService) { }

  @ViewChildren('listItem')
  public listItems!: QueryList<ElementRef<HTMLDivElement>>

  public ngAfterViewInit() {
  }

  public ModalRef?: BsModalRef;
  public eventoId?: number;

  public titulo: string = 'Ver Detalhes';
  public collapsed: boolean = true;

  public clientes: Cliente[] = [];
  public clientesFiltrados: Cliente[] = [];
  private _filtro: string = '';

  public get filtro(): string{
    return this._filtro;
  }

  public set filtro(value: string){
    this._filtro = value;
    this.clientesFiltrados = this._filtro ? this.filtrarClientes(): [];
  }

  public errorMessage: boolean = false;

  filtrarClientes(): Cliente[]{
    let clientesFiltrados = this.clientes.filter(cliente => {
      return cliente.nome.toLowerCase().includes(this._filtro.toLowerCase());
    });
    return clientesFiltrados;
  }

  expandDetails(index: number): void{
    let currentItem = this.listItems.get(index)?.nativeElement;

    if(this.listItems.length > 1){
      this.listItems.forEach(item => {
        if(item.nativeElement != currentItem){
          item.nativeElement.classList.add('collapsed');
        }
      });
    }

    currentItem?.classList.toggle('collapsed');
    this.setStatusCollapse();
    this.setNameTitulo();
  }

  setNameTitulo(): void{
    this.titulo = this.collapsed ? 'Ver Detalhes' : 'Fechar';
  }

  setStatusCollapse(): void{
    this.collapsed = !this.collapsed;
  }

  openModal(template: TemplateRef<any>): void{
    this.ModalRef = this.modalService.show(template);
  }

  confirm(): void{
    this.ModalRef?.hide();
  }

  decline(): void{
    this.ModalRef?.hide();
  }

  getClientes(): void{
    this.clienteService.getClientes().subscribe({
      next: (clientes: Cliente[]) => {
        this.clientes = [... clientes];
      },
      error: (error) => {
        this.errorMessage = true;
      },
      complete: () => {
        console.log("Carregado com sucesso"); //teste
        console.log(this.clientes); //teste
      }
    });
  }

  ngOnInit() {
    this.getClientes();
  }

}
