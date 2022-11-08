import { Component, ElementRef, EventEmitter, OnInit, Output, QueryList, TemplateRef, ViewChildren } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/models/Cliente';
import { ClienteService } from 'src/services/Cliente.service';

@Component({
  selector: 'app-clientes-home2-home',
  templateUrl: './clientes-home.component.html',
  styleUrls: ['./clientes-home.component.css']
})
export class ClientesHomeComponent implements OnInit {

  constructor(private clienteService: ClienteService, private modalService: BsModalService, private toastr: ToastrService) { }

  @ViewChildren('listItem')
  public listItems!: QueryList<ElementRef<HTMLDivElement>>

  public ngAfterViewInit() {
  }

  public ModalRef?: BsModalRef;
  public clienteId?: number;
  public clienteNome?: string;

  public collapsed: any = [];

  public clientes: Cliente[] = [];
  public clientesFiltrados: Cliente[] = [];
  private _filtro: string = '';

  public get filtro(): string{
    return this._filtro;
  }

  public set filtro(value: string){
    this._filtro = value;
    this.clientesFiltrados = this._filtro ? this.filtrarClientes(): [];
    this.setAllStatusCollapsed(true);
  }

  public errorMessage: boolean = false;

  private toastConfig: any = {
    timeOut: 3000,
    closeButton: true,
    progressBar: true,
    positionClass: 'toast-bottom-right',
  };

  setAllStatusCollapsed(fromFiltro: boolean = false): void{
    this.collapsed = this.clientesFiltrados.map(() => {
      return {statusCollapsed: true};
    });

    if(fromFiltro){
      this.listItems.forEach(item => {
        if(!item.nativeElement.classList.contains('collapsed')){
          item.nativeElement.classList.add('collapsed');
        }
      });
    }
  }

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
    this.setIndexStatusCollapsed(index);
  }

  setIndexStatusCollapsed(index: number): void{
    if(this.collapsed[index].statusCollapsed){
      this.setAllStatusCollapsed();
    }
    this.collapsed[index].statusCollapsed = !this.collapsed[index].statusCollapsed;
  }

  openModal(clienteNome: string, clienteId: number, template: TemplateRef<any>): void{
    this.clienteNome = clienteNome;
    this.clienteId = clienteId;
    this.ModalRef = this.modalService.show(template);
  }

  confirm(): void{
    this.ModalRef?.hide();
    if(this.clienteId != null){
      this.clienteService.deleteCliente(this.clienteId).subscribe({
        next: (messageObject: any) => {
          if(messageObject != null && messageObject.message == 'Deletado'){
            console.log(messageObject);
            this.toastr.success('Cliente excluído com sucesso', 'Êxito!', this.toastConfig);
          }
        },
        error: (error: any) => {
          console.log(error);
          this.toastr.error('Cliente não pôde ser deletado', 'Falha!', this.toastConfig);
        },
        complete: () => {
          this.getClientes();
        }
      });
    }
  }

  decline(): void{
    this.ModalRef?.hide();
  }

  getClientes(): void{
    this.clienteService.getClientes().subscribe({
      next: (clientes: Cliente[]) => {
        this.clientes = [... clientes];
        this.clientesFiltrados = this._filtro ? this.filtrarClientes(): [];
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
