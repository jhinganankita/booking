import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduledetailsComponent } from './scheduledetails.component';

describe('ScheduledetailsComponent', () => {
  let component: ScheduledetailsComponent;
  let fixture: ComponentFixture<ScheduledetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ScheduledetailsComponent]
    });
    fixture = TestBed.createComponent(ScheduledetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
