import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowEmpComponent } from './show-emp.component';
import { EmployeeService } from 'src/app/services/employee.service';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/models/employee-model';

xdescribe('ShowEmpComponent', () => {
  let component: ShowEmpComponent;
  let fixture: ComponentFixture<ShowEmpComponent>;
  let service: EmployeeService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowEmpComponent ],
      providers: [EmployeeService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowEmpComponent);
    component = fixture.componentInstance;
    service = TestBed.inject(EmployeeService);
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });

  // it('should return', () => {
  //   employees: Employee[] = [
  //     {
  //       employeeId: 1,
  //       employeeName: 'Test User 1',
  //       employeeDepartment: 'Test Dep 1',
  //       employeeEmail: 'testemail@email.com',
  //       employeeDoj: new Date('2020-01-01')
  //     }
  //   ];
  //   spyOn(service, 'getEmpList').and.callFake(() => {
  //     return Observable.from([employees]);
  //   });
  // });


});
