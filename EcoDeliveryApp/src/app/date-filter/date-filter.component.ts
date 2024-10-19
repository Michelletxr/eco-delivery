import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatDateFormats, MatNativeDateModule } from '@angular/material/core';
import { CommonModule } from '@angular/common';



export const MY_DATE_FORMATS: MatDateFormats = {
  parse: {
    dateInput: 'DD/MM/YYYY', // Como a data será lida no input
  },
  display: {
    dateInput: 'DD/MM/YYYY', // Como a data será exibida no input
    monthYearLabel: 'MMMM YYYY', // Exibição no seletor de mês e ano
    dateA11yLabel: 'LL', // Acessibilidade
    monthYearA11yLabel: 'MMMM YYYY', // Acessibilidade
  }
};

@Component({
  selector: 'app-date-filter',
  standalone: true,
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css'],
  imports: [
    FormsModule, 
    MatFormFieldModule, 
    MatInputModule, 
    MatDatepickerModule, 
    MatNativeDateModule, 
    CommonModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }, // Configura o idioma local
   // { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }, // Define os formatos personalizados
  ],
})
export class DateFilterComponent {

  startDate: Date | null = null;

  @Output() filterChange = new EventEmitter<{ startDate: string | null }>();

  applyFilter() {
    if(this.startDate){
      var dateString = this.convertDate(this.startDate.toString())
      this.filterChange.emit({ startDate: dateString });
    }
  }

  convertDate(dateString: string): string {
    const date = new Date(dateString);
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Mês começa em 0
    const year = date.getFullYear();
    return `${year}/${month}/${day}`; // Formato DD/MM/YYYY
  }
}

