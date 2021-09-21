import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatSnackBar } from '@angular/material/snack-bar';



@Component({
  selector: 'app-add-emp',
  templateUrl: './add-emp.component.html',
  styleUrls: ['./add-emp.component.css']
})
export class AddEmpComponent implements OnInit {

  constructor(
    public dialogBox: MatDialogRef<AddEmpComponent>,
    public service: EmployeeService,
    private snackBar: MatSnackBar
    ) { }

  ngOnInit(): void {
    this.resetForm();
    this.dropdownRefresh();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
    this.service.formData = {
      employeeId: 0,
      employeeName: '',
      employeeDepartment: '',
      employeeEmail:'',
      employeeDoj:undefined
    }
  }

  public listItems: Array<string> = [];

  dropdownRefresh()
  {
    this.service.getDepartmentDropdownValues().subscribe(data=>{
      data.forEach((element: { [x: string]: string; }) => {
        this.listItems.push(element["departmentName"]);
      });
    });
  }

  onClose() {
    this.dialogBox.close();
    this.service.filter('Register Click');
  }

  onSubmit(form: NgForm) {
    console.log(form.value['employeeDoj']);
    var d = new Date(form.value['employeeDoj']);
    // d.setMinutes(d.getMinutes() + d.getTimezoneOffset());
    d.setTime(d.getTime() - new Date().getTimezoneOffset()*60*1000);
    console.log(d);
    form.value['employeeDoj']=d;
    this.service.addEmployee(form.value).subscribe(res => {
      this.resetForm(form);
      this.snackBar.open("Added Successfully", '', {
        duration: 4500,
        verticalPosition: 'top'
      }
      );
    });
  }

}
