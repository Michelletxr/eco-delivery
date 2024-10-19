import { CommonModule, DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { RecibosService } from '../services/recibos.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-recibo-detail',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule, MatIconModule, MatDividerModule, HttpClientModule],
  templateUrl: './recibo-detail.component.html',
  styleUrl: './recibo-detail.component.css',
  providers: [DatePipe, RecibosService]
})

export class ReciboDetailComponent {
  
  constructor(
    private datePipe: DatePipe,
    private router: ActivatedRoute,
    private service: RecibosService,
    private http: HttpClient
  ) {}

  isCancelDisabled = true;
  @Input() recibo: any; 
  @Output() close = new EventEmitter<void>()
  reciboId: any;


  ngOnChanges(changes: SimpleChanges): void {
    this.updateButtonStates();

  }

  ngOnInit() {
    if(this.recibo){
      this.reciboId = this.recibo.id;
      this.updateButtonStates();
    }else{
      this.router.paramMap.subscribe(params => {
        this.reciboId = +params.get('id')!; // Recupera o ID como número
        this.getRecibo()
      });
    }
  }

  // Formatar a data no formato dd/MM/yyyy
  formatDate(date: string): string | null {
    return this.datePipe.transform(date, 'dd/MM/yyyy');
  }

  getRecibo(){
    this.service.getRecibo(this.reciboId).subscribe(
      (data) => {
        this.recibo = data;
        this.recibo.status = data.status
        this.updateButtonStates();
      },
      (error) => {
        console.error('Erro ao carregar o recibo:', error);
      }
    );
  }

  updateStatusRecibo(status: number){
    const url = 'http://localhost:5062/api/Contribuicao';
    const body = { id: this.recibo.id, status: status };
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    this.http.put(url, body, { headers }).subscribe((data:any)=>{
       this.recibo.status = data.status
       this.updateButtonStates();
     }, (error) => {
      console.error('Erro ao atualizar status de recibo:', error);
   });
  }
 
  updateButtonStates() {
    const status = this.recibo.status
    if(status == 1 || status == 3){
      this.isCancelDisabled = true;
    }else{
      this.isCancelDisabled = false;
    }
  }

  closeDetail() {
    this.close.emit(); 
  }

}
