import {Component, OnInit} from '@angular/core';
import {EmployeesProjectsModel} from "../models/UsersProjectsModel";
import {AppServiceService} from "../app-service.service";
import {BestPair} from "../models/BestPair";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  employees: EmployeesProjectsModel[] = [];
  bestPair: BestPair;

  constructor(private appService: AppServiceService) {
  }

  ngOnInit(): void {
    this.appService.getFileData().subscribe(res=>{
      this.employees = res;
    })
    this.appService.getBestPair().subscribe(res=> {
      this.bestPair = res;
    })
  }
}
