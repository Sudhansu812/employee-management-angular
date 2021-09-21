import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEmpComponent } from './add-emp.component';

xdescribe('AddEmpComponent', () => {
  let component: AddEmpComponent;
  let fixture: ComponentFixture<AddEmpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEmpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEmpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
