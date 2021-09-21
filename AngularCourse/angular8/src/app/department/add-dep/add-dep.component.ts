import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { DepartmentService } from 'src/app/services/department.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-add-dep',
  templateUrl: './add-dep.component.html',
  styleUrls: ['./add-dep.component.css']
})
export class AddDepComponent implements OnInit {

  constructor(
    public dialogBox: MatDialogRef<AddDepComponent>,
    public service:DepartmentService,
    private snackBar:MatSnackBar
    ) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?:NgForm)
  {
    if(form!=null)
    {
      form.resetForm();
    }
    this.service.formData={
      departmentId: 0,
      departmentName:''
    }
  }

  onClose()
  {
    this.dialogBox.close();
    this.service.filter('Register Click');
  }

  onSubmit(form:NgForm)
  {
    this.service.addDepartment(form.value).subscribe(res=>
      {
        this.resetForm(form);
        this.snackBar.open("Added Successfully", '', {
            duration:4500,
            verticalPosition:'top'
          }
        );
        // alert("Added Successfully");
      });
      
  }

}
