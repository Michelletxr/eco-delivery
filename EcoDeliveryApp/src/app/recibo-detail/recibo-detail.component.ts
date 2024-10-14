import { CommonModule, DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { RecibosService } from '../recibos.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

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
    private service: RecibosService
  ) {}

  
  isCancelDisabled = true;
  @Input() recibo: any; 
  @Output() close = new EventEmitter<void>()
  reciboId: any;

  ngOnInit() {
    if(this.recibo){
      this.reciboId = this.recibo.id;
      this.updateButtonStates();
      this.service.updateReciboStatus(this.recibo.id, 2)
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
        this.updateButtonStates();
      },
      (error) => {
        console.error('Erro ao carregar o recibo:', error);
      }
    );
  }

  updateStatusRecibo(status: number){
    this.service.updateReciboStatus(this.recibo.id, status)
    this.recibo.status = status
    this.updateButtonStates();
  }
 
  updateButtonStates() {
    this.isCancelDisabled = this.recibo.status != 2;
  }

   // Função para fechar o componente
  closeDetail() {
    this.close.emit(); 
  }

}
