import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReciboDetailComponent } from './recibo-detail.component';

describe('ReciboDetailComponent', () => {
  let component: ReciboDetailComponent;
  let fixture: ComponentFixture<ReciboDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReciboDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReciboDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
