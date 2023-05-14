import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {EmployeesComponent} from "./employees/employees.component";
import {UploadFileComponent} from "./upload-file/upload-file.component";

const routes: Routes = [
  {
    path: '',
    component: UploadFileComponent
  },
  {
    path: 'uploaded',
    component: EmployeesComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
