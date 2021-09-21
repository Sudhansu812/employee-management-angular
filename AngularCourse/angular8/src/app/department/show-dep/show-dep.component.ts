import { Component, OnInit } from '@angular/core';

import { Department } from 'src/app/models/department-model';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { ViewChild } from '@angular/core';
import { DepartmentService } from 'src/app/services/department.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddDepComponent } from '../add-dep/add-dep.component';
import { MatSnackBar } from '@angular/material/snack-bar';

import { EditDepComponent } from '../edit-dep/edit-dep.component';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css']
})


export class ShowDepComponent implements OnInit {

  constructor(private service: DepartmentService,
    private dialog: MatDialog,
      private snackBar: MatSnackBar) {
      this.service.listen().subscribe((m:any)=>{
        console.log();
        this.refreshDepartmentList();
      });
    }

  listData: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns : string[] = ['Options', 'departmentId', 'departmentName'];

  @ViewChild(MatSort) sort: MatSort;
  
  ngOnInit(): void {  
    this.listData.sort = this.sort;
    this.refreshDepartmentList();
  }

  refreshDepartmentList() {
    this.service.getDepList().subscribe(data => {
      this.listData = new MatTableDataSource(data);
      this.listData.sort = this.sort;
    });
  }
  
  applyFilter(filtervalue:string)
  {
    this.listData.filter = filtervalue.trim().toLowerCase();
  }

  onEdit(dep:Department,id: number){
    this.service.formData = dep;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "70%";
    this.dialog.open(EditDepComponent, dialogConfig);
    console.log(id);
  }
  
  onDelete(id:number){
    if(confirm('Are you sure, the data will be deleted permanently!'))
    {
      this.service.deleteDepartment(id).subscribe(res => {
        this.refreshDepartmentList();
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
    dialogConfig.width = "70%";
    this.dialog.open(AddDepComponent, dialogConfig);
  }

}







// This was inside redreshDepartmentList()
/*
  var dummyData = [{DepartmentId:1, DepartmentName:"IT"}, 
  { DepartmentId: 2, DepartmentName: "HR" },
  { DepartmentId: 3, DepartmentName: "Support" }];
  this.listData = new MatTableDataSource(dummyData);
*/