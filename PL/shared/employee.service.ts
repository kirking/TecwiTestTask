import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private fb:FormBuilder, private http:HttpClient) { }
  readonly baseURL = 'https://localhost:44373/api';

  formModel = this.fb.group({
    Name: ['', [Validators.required, Validators.pattern("^(\\w+ ?)*$")]],
    Position: ['', [Validators.required, Validators.pattern("^(\\w+ ?)*$")]],
    Age: ['', [Validators.required, Validators.pattern("\\b(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])\\b")]],
    StartDate: ['', [Validators.required, Validators.pattern("([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))")]]
  });

  nameFormModel = this.fb.group({
    id: ['', [Validators.required, Validators.pattern("\\d*")]],
    newName: ['', [Validators.required, Validators.pattern("^(\\w+ ?)*$")]]
  });

  positionFormModel = this.fb.group({
    id: ['', [Validators.required, Validators.pattern("\\d*")]],
    newPosition: ['', [Validators.required, Validators.pattern("^(\\w+ ?)*$")]],
  });

  ageFormModel = this.fb.group({
    id: ['', [Validators.required, Validators.pattern("\\d*")]],
    newAge: ['', [Validators.required, Validators.pattern("\\b(1?[0-9]{1,2}|2[0-4][0-9]|25[0-5])\\b")]]
  });

  startDateFormModel = this.fb.group({
    id: ['', [Validators.required, Validators.pattern("\\d*")]],
    newStartDate: ['', [Validators.required, Validators.pattern("([12]\\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01]))")]]
  });

  deleteFormModel = this.fb.group({
    id: ['', [Validators.required, Validators.pattern("\\d*")]]
  });

  getAllEmployees() {
    return this.http.get(this.baseURL + '/employee/browse');
  }

  insertEmployee() {
    var body = {
      Name: this.formModel.value.Name,
      Position: this.formModel.value.Position,
      Age: Number(this.formModel.value.Age),
      StartDate: this.formModel.value.StartDate + "T00:00:00.000"
    }
    return this.http.post(this.baseURL + '/employee/add', body)
  }

  deleteEmployee() {
    return this.http.post(this.baseURL + '/employee/delete?employeeId=' + this.deleteFormModel.value.id, null);
  }

  changeName() {
    return this.http.post(this.baseURL + '/employee/changename?employeeId=' + this.nameFormModel.value.id + '&newName=' + this.nameFormModel.value.newName, null);
  }

  changePosition() {
    return this.http.post(this.baseURL + '/employee/changeposition?employeeId=' + this.positionFormModel.value.id + '&newPosition=' + this.positionFormModel.value.newPosition, null);
  }

  changeAge() {
    return this.http.post(this.baseURL + '/employee/changeage?employeeId=' + this.ageFormModel.value.id + '&newAge=' + this.ageFormModel.value.newAge, null);
  }

  changeStartDate() {
    return this.http.post(this.baseURL + '/employee/changestartdate?employeeId=' + this.startDateFormModel.value.id + '&newStartDate=' + this.startDateFormModel.value.newStartDate, null);
  }
}
