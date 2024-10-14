import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

export interface Contribuinte {
  id: number;
  nome: string;
  endereco: string;
  telefone: string;
}

export interface Recibo {
  id: number;
  valor: number;
  tipoPagamento: string | null;
  data_Prevista: string;
  data_Recebimento: string;  
  status: number;
  contribuinte: Contribuinte | null;
}

export interface MovimentoDiario {
  id: number;
  data_Movimento: string; 
  mensageiro: Mensageiro | null;  
  contribuicaoRecibo: ContribuicaoRecibo;  
}

export interface Mensageiro {
  id: number;
  nome: string;
}

export interface ContribuicaoRecibo {
  id: number;
  valor: number;
  tipoPagamento: string | null; 
  contribuinte: Contribuinte | null;
  data_Prevista: string;  
  data_Recebimento: string; 
  status: number;  
}

@Injectable({
  providedIn: 'root'
})
export class RecibosService {

  constructor(private http: HttpClient) {}

  private apiUrl = 'http://localhost:5062/api'; 

  getRecibos(): Observable<Recibo[]> {
    return this.http.get<Recibo[]>(this.apiUrl);
  }

  getMovimentosDiarios(id: Number):Observable<any> {
    return this.http.get(`${this.apiUrl}/Mensageiro/movimentoDiario/${id}`);
  }

  getMovimentosDiariosByDate(id: Number){
    return this.http.get(`${this.apiUrl}/Mensageiro/movimentoDiario/${id}?dataPrevista=2024-10-12`);
  }

  getRecibo(id: Number): Observable<any> {
    return this.http.get(`${this.apiUrl}/Contribuicao/${id}`);
  }

  updateReciboStatus(id: number, status: number): Observable<any> {
    const updatePayload = { status }; 
    return this.http.put(`${this.apiUrl}/Contribuicao/${id}`, updatePayload);
  }

}
