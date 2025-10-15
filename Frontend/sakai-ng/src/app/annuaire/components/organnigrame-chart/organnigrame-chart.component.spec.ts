import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrgannigrameChartComponent } from './organnigrame-chart.component';

describe('OrgannigrameChartComponent', () => {
  let component: OrgannigrameChartComponent;
  let fixture: ComponentFixture<OrgannigrameChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrgannigrameChartComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrgannigrameChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
