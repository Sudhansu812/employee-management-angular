import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { DepartmentService } from './department.service';
import { Department } from '../models/department-model';

describe('DepartmentService', () => {
  let service: DepartmentService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [DepartmentService]
    });
    service = TestBed.inject(DepartmentService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('shouldRetreive posts from the API via GET', () => {
    const dummyPost: Department[] = [
      { "departmentId": 1, "departmentName": "IT" }, 
      { "departmentId": 2, "departmentName": "Finance" }, 
      { "departmentId": 3, "departmentName": "HR" }, 
      { "departmentId": 4, "departmentName": "Security" }, 
      { "departmentId": 5, "departmentName": "R&D" }, 
      { "departmentId": 6, "departmentName": "Development" }, 
      { "departmentId": 7, "departmentName": "Customer" }, 
      { "departmentId": 8, "departmentName": "Testing" }, 
      { "departmentId": 9, "departmentName": "Mainframe" }, 
      { "departmentId": 10, "departmentName": "Marketing" }, 
      { "departmentId": 11, "departmentName": "Sales" }
    ];

    service.getDepList().subscribe(deps => {
      expect(deps.length).toBe(dummyPost.length);
      expect(deps).toEqual(dummyPost);
    });
    const request = httpMock.expectOne(service.ApiUrl + '/departments');
    expect(request.request.method).toBe('GET');
    request.flush(dummyPost);
  });


});

