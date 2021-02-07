import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'shared/employee.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  constructor(public service: EmployeeService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.insertEmployee().subscribe(
      (res:any) => {
        if (res == true) {
          this.service.formModel.reset();
          this.toastr.success('Employee added successfully', 'Employee Manager');
        }
        else {
          this.toastr.error('An error occurred while adding an employee', 'Employee Manager');
        }
      },
      err => {
        this.toastr.error('An error occurred while adding an employee', 'Employee Manager');
      }
    );
  }
}
