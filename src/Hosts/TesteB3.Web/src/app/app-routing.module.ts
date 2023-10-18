import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ScheduleListComponent } from './schedule/schedule-list/schedule-list.component';

const routes: Routes = [
  { path: '', component: ScheduleListComponent  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
