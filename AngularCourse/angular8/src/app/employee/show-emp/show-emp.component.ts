import { Component, OnInit } from '@angular/core';

import { Employee} from 'src/app/models/employee-model';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { ViewChild } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddEmpComponent } from '../add-emp/add-emp.component';
import { MatSnackBar } from '@angular/material/snack-bar';

import { EditEmpComponent } from '../edit-emp/edit-emp.component';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(
    private service: EmployeeService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar) {
    this.service.listen().subscribe((m: any) => {
      console.log();
      this.refreshEmployeeList();
    });
  }

  listData: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns: string[] = ['Options', 'employeeId', 'employeeName', 'employeeDepartment', 'employeeEmail', 'employeeDoj'];

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit(): void {
    this.listData.sort = this.sort;
    this.refreshEmployeeList();
  }

  refreshEmployeeList() {
    this.service.getEmpList().subscribe(data => {
      this.listData = new MatTableDataSource(data);
      this.listData.sort = this.sort;
    });
  }

  applyFilter(filtervalue: string) {
    this.listData.filter = filtervalue.trim().toLowerCase();
  }
  
  onEdit(emp: Employee, id: number)
  {
    this.service.formData = emp;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "70%";
    this.dialog.open(EditEmpComponent, dialogConfig);
    console.log(id);
  }
  
  onDelete(id: number)
  {
    if (confirm('Are you sure, the data will be deleted permanently!')) {
      this.service.deleteEmployee(id).subscribe(res => {
        this.refreshEmployeeList();
        this.snackBar.open("Deleted Successfully", '', {
          duration: 4500,
          verticalPosition: 'top'
        }
        );
      });
    }
  }

  onAdd()
  {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    this.dialog.open(AddEmpComponent, dialogConfig);
  }

}
