import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-date-filter',
  standalone: true,
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css'],
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatDatepickerModule, MatNativeDateModule, CommonModule]
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
    return `${year}-${month}-${day}`;
  }
}
