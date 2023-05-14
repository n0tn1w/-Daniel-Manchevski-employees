import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../environments/environment";
import {Observable, of} from "rxjs";
import {EmployeesProjectsModel} from "./models/UsersProjectsModel";
import {BestPair} from "./models/BestPair";

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  backEndURL = environment.BEUrl;

  constructor(private  httpClient: HttpClient) { }

  postUploadFile(data: any): Observable<boolean> {
    const url=`${this.backEndURL}/Employees/Upload`;
    return this.httpClient.post<boolean>(url, data);
  }

  getFileData(): Observable<EmployeesProjectsModel[]> {
    const url=`${this.backEndURL}/Employees`;
    return this.httpClient.get<EmployeesProjectsModel[]>(url);
  }

  getBestPair(): Observable<BestPair> {
    const url=`${this.backEndURL}/Employees/Pair`;
    return this.httpClient.get<BestPair>(url);
  }
}
