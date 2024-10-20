import { Component, OnInit } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import { RecibosService, Recibo, MovimentoDiario } from '../services/recibos.service';
import { HttpClientModule } from '@angular/common/http';
import { DateFilterComponent } from '../date-filter/date-filter.component';
import { CommonModule, DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(private recibosService: RecibosService, private datePipe: DatePipe, private router: Router, private route: ActivatedRoute) {}
  id: string | null = null; 
  displayedColumns: string[] = ['numeroRecibo', 'valor', 'status', 'dataPrevista', 'dataMovimento', 'visualizar'];
  dataSource = new MatTableDataSource<MovimentoDiario>();
  mov_diarios: MovimentoDiario[] = [];
  recibos: Recibo[] = []
  selectedRecibo: any
  showRecibo = false
    
  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id'); // Pega o valor de 'jti' da URL
    this.loadData();
  }

  loadData(){
    // verifica se existe um valor de id
    if(this.id){
      var id = Number(this.id);
      this.recibosService.getMovimentosDiarios(id).subscribe((data: MovimentoDiario[]) => {
        this.dataSource.data = data;
      }, (error) => {
       console.error('Erro ao carregar os movimentos diarios:', error);
     });
    }
  }

  goToReciboDetail(reciboId: number) {
    this.router.navigate(['/recibo', reciboId]);
  }

  selectRecibo(recibo: any) {
    this.showRecibo = true;
    this.selectedRecibo = recibo;
  }

  onCloseDetail() {
    this.showRecibo = false;
  }

  onFilterChange(event: { startDate: string | null }) {
    if(event.startDate){
      this.recibosService.getMovimentosDiariosByDate(Number(this.id), event.startDate).subscribe((data: MovimentoDiario[]) => {
        this.dataSource.data = data;
     }, (error) => {
        console.error('Erro ao carregar os movimentos diarios:', error);
     });
    }
  }

}
