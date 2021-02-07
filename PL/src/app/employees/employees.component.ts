import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'shared/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  listOfEmployees;
  name = '';
  position = '';
  age = '';

  constructor(private productService: EmployeeService) { }

  ngOnInit(): void {
    this.productService.getAllEmployees().subscribe(
      res => {
        this.listOfEmployees = res;
      },
      err => {
        console.log(err);
      },
    )
  }}
