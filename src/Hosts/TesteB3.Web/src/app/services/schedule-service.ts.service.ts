import { Injectable } from '@angular/core';
import { Schedule } from './../models/schedule';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ScheduleServiceTsService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Schedule[]>(`${environment.baseAddress}/schedules`);
  }

  getById(id: string) {
    return this.http.get<Schedule>(`${environment.baseAddress}/schedules/${id}`);
  }

  delete(id: string) {
    return this.http.delete(`${environment.baseAddress}/schedules/${id}`);
  }

  save(schedule: Schedule) {
    return this.http.post<Schedule>(`${environment.baseAddress}/schedules`, schedule);
  }

  update(id: string, schedule: Schedule) {
    return this.http.put(`${environment.baseAddress}/schedules/${id}`, schedule);
  }
}
