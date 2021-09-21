import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { DepartmentService } from 'src/app/services/department.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-dep',
  templateUrl: './edit-dep.component.html',
  styleUrls: ['./edit-dep.component.css']
})
export class EditDepComponent implements OnInit {

  constructor(public dialogBox: MatDialogRef<EditDepComponent>,
    public service: DepartmentService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  onClose() {
    this.dialogBox.close();
    this.service.filter('Register Click');
  }

  onSubmit(form:NgForm)
  {
    this.service.updateDepartment(form.value).subscribe(res => {
      this.snackBar.open('Updated Successfully', '', {
        duration:4500,
        verticalPosition:'top'
      });
    })
  }

}
