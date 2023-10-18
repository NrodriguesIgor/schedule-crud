import { TestBed } from '@angular/core/testing';

import { ScheduleServiceTsService } from './schedule-service.ts.service';

describe('ScheduleServiceTsService', () => {
  let service: ScheduleServiceTsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScheduleServiceTsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
