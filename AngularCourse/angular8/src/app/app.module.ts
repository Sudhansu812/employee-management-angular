import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { MatTableModule} from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { FormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmployeeComponent } from './employee/employee.component';
import { ShowEmpComponent } from './employee/show-emp/show-emp.component';
import { EditEmpComponent } from './employee/edit-emp/edit-emp.component';
import { AddEmpComponent } from './employee/add-emp/add-emp.component';
import { DepartmentComponent } from './department/department.component';
import { ShowDepComponent } from './department/show-dep/show-dep.component';
import { EditDepComponent } from './department/edit-dep/edit-dep.component';
import { AddDepComponent } from './department/add-dep/add-dep.component';
import { MatDialogModule } from '@angular/material/dialog';

// Providers
import { DepartmentService } from './services/department.service';
import { EmployeeService } from './services/employee.service';


// import { MatSliderModule } from '@angular/material/slider';

// @NgModule({
//   imports: [
//     MatSliderModule,
//   ]
// })

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    ShowEmpComponent,
    EditEmpComponent,
    AddEmpComponent,
    DepartmentComponent,
    ShowDepComponent,
    EditDepComponent,
    AddDepComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    HttpClientModule,
    MatSortModule,
    MatDialogModule,
    FormsModule,
    MatSnackBarModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [
    DepartmentService,
    EmployeeService,
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    AddDepComponent, 
    EditDepComponent, 
    AddEmpComponent,
    EditEmpComponent
  ]
})
export class AppModule { }
