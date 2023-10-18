import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ScheduleServiceTsService } from 'src/app/services/schedule-service.ts.service';
import { MatSlideToggle,MatSlideToggleChange } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-schedule-edit',
  templateUrl: './schedule-edit.component.html',
  styleUrls: ['./schedule-edit.component.css']
})
export class ScheduleEditComponent implements OnInit {

  scheduleForm: FormGroup;

  constructor(private formBuilder : FormBuilder, 
    private _dialogRef: MatDialogRef<ScheduleEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private scheduleService: ScheduleServiceTsService) {
    this.scheduleForm = formBuilder.group({
      'description':'',
      'date':'',
      'done':''
    })
   }

  ngOnInit(): void {
    this.scheduleForm.patchValue(this.data);
  }

  onFormSubmit() {
    if (this.scheduleForm.valid) {
      if (this.data) {
        this.scheduleService
          .update(this.data.id, this.scheduleForm.value)
          .subscribe({
            next: (val: any) => {
              this._dialogRef.close(true);
            },
            error: (err: any) => {
              console.error(err);
            },
          });
      } else {
        this.scheduleService.save(this.scheduleForm.value).subscribe({
          next: (val: any) => {
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    }
  }
}


