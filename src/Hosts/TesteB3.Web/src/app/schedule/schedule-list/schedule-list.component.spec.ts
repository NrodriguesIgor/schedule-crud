import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleListComponent } from './schedule-list.component';
import { Schedule } from 'src/app/models/schedule';


describe('ScheduleListComponent', () => {
  let component: ScheduleListComponent;
  let fixture: ComponentFixture<ScheduleListComponent>;
  let schedules: Array<Schedule>
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScheduleListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScheduleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
