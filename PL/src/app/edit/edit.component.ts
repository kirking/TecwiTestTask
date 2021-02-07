import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from 'shared/employee.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  
  constructor(public service: EmployeeService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onNameSubmit() {
    this.service.changeName().subscribe(
      (res:any) => {
        if (res) {
        this.service.nameFormModel.reset();
        this.toastr.success('Employee\'s name editing successfully', 'Employee Manager');
      }
      else {
        this.toastr.error('An error occurred while editing an employee\'s position', 'Employee Manager');
      }
      },
      err => {
        this.toastr.error('An error occurred while editing an employee\'s position', 'Employee Manager');
      }
    );
  }

  onPositionSubmit() {
    this.service.changePosition().subscribe(
      (res:any) => {
        if (res) {
        this.service.positionFormModel.reset();
        this.toastr.success('Employee\'s position editing successfully', 'Employee Manager');
        }
        else {
          this.toastr.error('An error occurred while editing an employee\'s position', 'Employee Manager');
        }
      },
      err => {
        this.toastr.error('An error occurred while editing an employee\'s position', 'Employee Manager');
      }
    );
  }

  onAgeSubmit() {
    this.service.changeAge().subscribe(
      (res:any) => {
        if (res) {
        this.service.ageFormModel.reset();
        this.toastr.success('Employee\'s age editing successfully', 'Employee Manager');
      }
      else {
        this.toastr.error('An error occurred while editing an employee\'s position', 'Employee Manager');
      }
      },
      err => {
        this.toastr.error('An error occurred while editing an employee\'s age', 'Employee Manager');
      }
    );
  }

  onStartDateSubmit() {
    this.service.changeStartDate().subscribe(
      (res:any) => {
        if (res) {
        this.service.startDateFormModel.reset();
        this.toastr.success('Employee\'s start date editing successfully', 'Employee Manager');
      }
      else {
        this.toastr.error('An error occurred while editing an employee\'s position', 'Employee Manager');
      }
      },
      err => {
        this.toastr.error('An error occurred while editing an employee\'s start date', 'Employee Manager');
      }
    );
  }
}
