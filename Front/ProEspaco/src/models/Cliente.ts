export interface Cliente {
  id: Number;
  nome: string;
  telefone: string;
  cep?: string;
  endereco?: string;
  bairro?: string;
  cidade?: string;
  dataCriacao: string;
}
