import { Component, OnInit } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import { RecibosService, Recibo, MovimentoDiario } from '../recibos.service';
import { HttpClientModule } from '@angular/common/http';
import { DateFilterComponent } from '../date-filter/date-filter.component';
import { CommonModule, DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { ReciboDetailComponent } from '../recibo-detail/recibo-detail.component';


@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MatTableModule, MatFormFieldModule, MatIconModule, HttpClientModule, DateFilterComponent, CommonModule, ReciboDetailComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  providers: [RecibosService, DatePipe]  // Forneça o RecibosService aqui
})
export class DashboardComponent  implements OnInit {

  constructor(private recibosService: RecibosService, private datePipe: DatePipe, private router: Router) {}
  
  displayedColumns: string[] = ['numeroRecibo', 'valor', 'status', 'dataPrevista', 'dataMovimento', 'visualizar'];
  dataSource = new MatTableDataSource<MovimentoDiario>();
  mov_diarios: MovimentoDiario[] = [];
  recibos: Recibo[] = []
  selectedRecibo: any
  showRecibo = false
 
  // Função para aplicar o filtro
  applyFilter(event: Event) {
    this.dataSource.data = this.mov_diarios;
  }

  goToReciboDetail(reciboId: number) {
    this.router.navigate(['/recibo', reciboId]);
  }
    
  ngOnInit() {
    this.recibosService.getMovimentosDiarios(1).subscribe((data: MovimentoDiario[]) => {
       this.dataSource.data = data;
    }, (error) => {
      console.error('Erro ao carregar os movimentos diarios:', error);
    });
  }

  selectRecibo(recibo: any) {
    this.showRecibo = true;
    this.selectedRecibo = recibo;
  }

  closeDetail() {
    this.showRecibo = false;
  }

}
