import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Employee } from '../models/employee-model';
import { Observable } from 'rxjs';

import { Subject } from 'rxjs';
import { Department } from '../models/department-model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  formData: Employee;

  readonly ApiUrl = "https://localhost:44305/api";

  getEmpList(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.ApiUrl + "/employees");
  }

  addEmployee(emp: Employee) {
    return this.http.post(this.ApiUrl + '/employees', emp);
  }

  deleteEmployee(id: number) {
    return this.http.delete(this.ApiUrl + '/employees/' + id);
  }

  updateEmployee(emp: Employee) {
    return this.http.put(this.ApiUrl + '/employees', emp);
  }

  getDepartmentDropdownValues(): Observable<any>
  {
    return this.http.get<Department[]>(this.ApiUrl+'/departments');
  }

  // The following methods are for refreshing the grid even after closing the
  // dialog box.
  private _listeners = new Subject<any>();
  listen(): Observable<any> {
    return this._listeners.asObservable();
  }
  filter(filterBy: string) {
    this._listeners.next(filterBy);
  }
}
