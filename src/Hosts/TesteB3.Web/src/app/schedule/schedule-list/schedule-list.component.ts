import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Schedule } from 'src/app/models/schedule';
import { ScheduleServiceTsService } from 'src/app/services/schedule-service.ts.service';
import { MatIcon } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { ScheduleEditComponent } from '../schedule-edit/schedule-edit.component';

@Component({
  selector: 'app-schedule-list',
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.css'],

})
export class ScheduleListComponent implements OnInit {

  public displayedColumns = ['id', 'description', 'done', 'date', 'action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private scheduleService: ScheduleServiceTsService,   private _dialog: MatDialog,) { }

  ngOnInit(): void {
    this.getSchedules();
  }

  getSchedules() {

    this.scheduleService.getAll().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;

    });;

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteSchedule(id: string) {
    if (confirm("Deseja Realmente Excluir o Registro?")) {
      this.scheduleService.delete(id).subscribe(() => {
        this.getSchedules();
      })
    }
  }

  openNewDialog() {
    const dialogRef = this._dialog.open(ScheduleEditComponent,{      

    });
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getSchedules();
        }
      },
    });
  }

  openEditForm(data: any) {
    const dialogRef = this._dialog.open(ScheduleEditComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getSchedules();
        }
      },
    });
  }

}
