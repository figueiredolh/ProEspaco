import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ExtractCepNumbers } from 'src/helpers/extractCepNumbers';
import { Cliente } from 'src/models/Cliente';
import { CepService } from 'src/services/cepService/Cep.service';
import { ClienteService } from 'src/services/Cliente.service';

@Component({
  selector: 'app-clientes-cadastro',
  templateUrl: './clientes-cadastro.component.html',
  styleUrls: ['./clientes-cadastro.component.css']
})
export class ClientesCadastroComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private clienteService: ClienteService, private toastrService: ToastrService,
              private cepService: CepService) { }

  public cliente!: Cliente;
  public form!: FormGroup;

  public get f(){
    return this.form.controls;
  }

  private toastConfig: any = {
    timeOut: 3000,
    closeButton: true,
    progressBar: true,
    positionClass: 'toast-bottom-right',
  };

  public lastCep?: string;

  public formGroup(): void{
    this.form = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.maxLength(40)]],
      telefone: ['', [Validators.required, Validators.minLength(15), Validators.maxLength(15)]], //pattern
      cpf: ['', [Validators.minLength(14), Validators.maxLength(14)]],
      cep: ['', [Validators.minLength(9), Validators.maxLength(9)]], //pattern
      endereco: ['', [Validators.maxLength(40)]],
      bairro: ['', [Validators.maxLength(40)]],
      cidade: ['', [Validators.maxLength(40)]],
    });
  }

  public feedbackVisibility(controlName: AbstractControl): string{
    return controlName.errors && controlName.touched ? 'visible' : 'hidden';
  }

  public saveChanges(){
    if(this.form.valid){
      this.cliente = {... this.form.value}
      this.clienteService.postCliente(this.cliente).subscribe({
        next: (cliente: Cliente) => {
          console.log(cliente); //teste
          this.toastrService.success(`Cliente cadastrado com sucesso!. ID ${cliente.id}`, 'Êxito!', this.toastConfig);
        },
        error: (error) => {
          console.log(error);
          this.toastrService.error('Cliente não pôde ser cadastrado', 'Falha!', this.toastConfig);
        }
      });
    }
  }

  public getCep(cepControl: AbstractControl){
    if(!cepControl.valid || cepControl.value.length == 0){
      this.lastCep = '';
      return;
    }

    let cepOnlyNumbers = ExtractCepNumbers.extractNumbers(cepControl.value);

    if(cepControl.valid && this.lastCep === cepOnlyNumbers){
      return;
    }

    this.cepService.getCep(cepOnlyNumbers).subscribe({
      next: (infoCep: any) => {
        this.f.endereco.patchValue(infoCep.logradouro);
        this.f.bairro.patchValue(infoCep.bairro);
        this.f.cidade.patchValue(infoCep.localidade);
        this.lastCep = cepOnlyNumbers;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  ngOnInit() {
    this.formGroup();
  }

}
