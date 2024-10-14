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
  endDate: Date | null = null;

  @Output() filterChange = new EventEmitter<{ startDate: Date | null, endDate: Date | null }>();

  applyFilter() {
    this.filterChange.emit({ startDate: this.startDate, endDate: this.endDate });
  }
}
