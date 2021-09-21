import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-emp',
  templateUrl: './edit-emp.component.html',
  styleUrls: ['./edit-emp.component.css']
})
export class EditEmpComponent implements OnInit {

  constructor(public dialogBox: MatDialogRef<EditEmpComponent>,
    public service: EmployeeService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.dropdownRefresh();
  }

  public listItems: Array<string> = [];

  dropdownRefresh() {
    this.service.getDepartmentDropdownValues().subscribe(data => {
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
    d.setTime(d.getTime() - new Date().getTimezoneOffset() * 60 * 1000);
    console.log(d);
    form.value['employeeDoj'] = d;
    this.service.updateEmployee(form.value).subscribe(res => {
      this.snackBar.open('Updated Successfully', '', {
        duration: 4500,
        verticalPosition: 'top'
      });
    })
  }
}
