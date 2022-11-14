import { Component, ElementRef, EventEmitter, OnInit, Output, QueryList, TemplateRef, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  constructor(private clienteService: ClienteService, private modalService: BsModalService,
              private toastrService: ToastrService, private formBuilder: FormBuilder) { }

  @ViewChildren('listContentItem')
  public listContentItems!: QueryList<ElementRef<HTMLDivElement>>

  public ngAfterViewInit() {
  }

  ngOnInit() {
    this.getClientes();
    this.formGroup();
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
      this.listContentItems.forEach(item => {
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
    let currentDiv = this.listContentItems.get(index)?.nativeElement;

    if(this.listContentItems.length > 1){
      this.listContentItems.forEach(item => {
        if(item.nativeElement != currentDiv){
          item.nativeElement.classList.add('collapsed');
        }
      });
    }

    currentDiv?.classList.toggle('collapsed');
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

  getClientes(): void{
    this.clienteService.getClientes().subscribe({
      next: (clientes: Cliente[]) => {
        this.clientes = [... clientes];
        this.clientesFiltrados = this._filtro ? this.filtrarClientes(): [];
      },
      error: () => {
        this.errorMessage = true;
      },
      complete: () => {
        console.log("Carregado com sucesso"); //teste
        console.log(this.clientes); //teste
      }
    });
  }

  confirm(): void{
    this.ModalRef?.hide();
    if(this.clienteId != null){
      this.clienteService.deleteCliente(this.clienteId).subscribe({
        next: (messageObject: any) => {
          if(messageObject != null && messageObject.message == 'Deletado'){
            console.log(messageObject);
            this.toastrService.success('Cliente excluído com sucesso', 'Êxito!', this.toastConfig);
          }
        },
        error: (error: any) => {
          console.log(error);
          this.toastrService.error('Cliente não pôde ser deletado', 'Falha!', this.toastConfig);
        },
        complete: () => {
          this.getClientes();
          this.setAllStatusCollapsed(true);
        }
      });
    }
  }

  decline(): void{
    this.ModalRef?.hide();
  }

  /* Form Control e Update */

  public cliente!: Cliente;
  public formUpdate!: FormGroup;

  public get formControls(){
    return this.formUpdate.controls;
  }

  public getClienteToUpdate(id: number): Cliente{
    let cliente = this.clientesFiltrados.filter((cliente)=>{
      return cliente.id === id;
    });

    return cliente[0];
  }

  public clienteFormEditionSwitch(listItems: QueryList<ElementRef<HTMLDivElement>>, clienteId: number, index: number, divContent: string){
    let currentDiv = listItems.get(index)?.nativeElement;
    let divTextContent = currentDiv?.querySelector(divContent);
    let divEditContent = divTextContent?.nextElementSibling;

    if(divEditContent?.classList.contains('no-edit') || clienteId < 0 || !clienteId){
      this.formUpdate.patchValue(this.getClienteToUpdate(clienteId));
    }

    divTextContent?.classList.toggle('no-edit');
    divEditContent?.classList.toggle('no-edit');
  }

  public telefoneEditSwitch(clienteId: number, index: number): void{
    this.clienteFormEditionSwitch(this.listContentItems, clienteId, index, '.telefone-content-text');
  }

  public enderecoEditSwitch(clienteId: number, index: number): void{
    this.clienteFormEditionSwitch(this.listContentItems, clienteId, index, '.endereco-content-text');
  }

  public closeEditionAfterUpdate(index: number){
    let currentDiv = this.listContentItems.get(index)?.nativeElement;
    let divEditContent = currentDiv?.querySelectorAll('div[class$="text-edit"]');

    divEditContent?.forEach((divEdit)=>{
      let divTextContent = divEdit?.previousElementSibling;

      divTextContent?.classList.remove('no-edit');
      divEdit.classList.add('no-edit');
    });
  }

  public updateCliente(index: number){
    this.cliente = {... this.formUpdate.value}
    console.log(this.cliente);
    this.clienteService.putCliente(this.cliente).subscribe({
      next: (cliente: Cliente) => {
        console.log(cliente);
        this.toastrService.success(`Cliente ${this.cliente.id} atualizado com sucesso`, 'Êxito!', this.toastConfig);
      },
      error: (error) => {
        console.log(error);
        this.toastrService.error(`Cliente ${this.cliente.id} não pôde ser atualizado`, 'Falha!', this.toastConfig);
      },
      complete: () => {
        this.closeEditionAfterUpdate(index);
        this.getClientes();
        this.setAllStatusCollapsed(true);
      }
    });
  }

  public formGroup(): void{
    this.formUpdate = this.formBuilder.group({
      id: [''],
      nome: ['', [Validators.required, Validators.maxLength(40)]],
      telefone: ['', [Validators.required, Validators.minLength(15), Validators.maxLength(15)]], //pattern
      cep: ['', [Validators.minLength(9), Validators.maxLength(9)]], //pattern
      endereco: ['', [Validators.maxLength(40)]],
      bairro: ['', [Validators.maxLength(40)]],
      cidade: ['', [Validators.maxLength(40)]],
    });
  }
}
