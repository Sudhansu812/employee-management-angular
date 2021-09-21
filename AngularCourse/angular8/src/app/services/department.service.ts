import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Department } from '../models/department-model';
import { Observable } from 'rxjs';

import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http:HttpClient) { }

  formData: Department;

  readonly ApiUrl = "https://localhost:44305/api";

  getDepList() : Observable<Department[]>
  {
    return this.http.get<Department[]>(this.ApiUrl + "/departments");
  }

  addDepartment(dep:Department)
  {
    return this.http.post(this.ApiUrl + '/departments', dep);
  }

  deleteDepartment(id:number)
  {
    return this.http.delete(this.ApiUrl + '/departments/' + id);
  }

  updateDepartment(dep:Department)
  {
    return this.http.put(this.ApiUrl+'/departments', dep);
  }

  // The following methods are for refreshing the grid even after closing the
  // dialog box.
  private _listeners = new Subject<any>();
  listen():Observable<any>{
    return this._listeners.asObservable();
  }
  filter(filterBy:string)
  {
    this._listeners.next(filterBy);
  }

}
