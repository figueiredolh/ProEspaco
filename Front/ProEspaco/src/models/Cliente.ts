export interface Cliente {
  id: number;
  nome: string;
  telefone: string;
  cep?: string;
  endereco?: string;
  bairro?: string;
  cidade?: string;
  dataCriacao: string;
}
