import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-clientes-cadastro',
  templateUrl: './clientes-cadastro.component.html',
  styleUrls: ['./clientes-cadastro.component.css']
})
export class ClientesCadastroComponent implements OnInit {

  constructor(private _formBuilder: FormBuilder) { }

  public form!: FormGroup;

  public get f(){
    return this.form.controls;
  }

  public formGroup(): void{
    this.form = this._formBuilder.group({
      nome: ['', [Validators.required, Validators.maxLength(40)]],
      telefone: ['', [Validators.required, Validators.minLength(15), Validators.maxLength(15)]], //pattern
      cpf: ['', [Validators.minLength(14), Validators.maxLength(14)]],
      cep: ['', [Validators.minLength(9), Validators.maxLength(9)]], //pattern
      endereco: ['', [Validators.maxLength(40)]],
      bairro: ['', [Validators.maxLength(40)]],
    });
  }

  public feedbackVisibility(controlName: AbstractControl): string{
    return controlName.errors && controlName.touched ? 'visible' : 'hidden';
  }

  ngOnInit() {
    this.formGroup();
  }

}
