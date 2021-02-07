import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from 'shared/employee.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  
  constructor(public service: EmployeeService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.deleteEmployee().subscribe(
      (res:any) => {
        if (res == true) {
          this.service.deleteFormModel.reset();
          this.toastr.success('Employee delete successfully', 'Employee Manager');
        }
        else {
          this.toastr.error('An error occurred while deleting an employee', 'Employee Manager');
        }
      },
      err => {
        this.toastr.error('An error occurred while deleting an employee', 'Employee Manager');
      }
    );
  }
}
