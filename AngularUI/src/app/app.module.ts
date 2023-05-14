import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {RouterModule} from "@angular/router";
import { EmployeesComponent } from './employees/employees.component';
import {AppRoutingModule} from "./app-routing.module";
import { UploadFileComponent } from './upload-file/upload-file.component';
import {HttpClientModule} from "@angular/common/http";
import {CommonModule} from "@angular/common";

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    UploadFileComponent
  ],
    imports: [
      AppRoutingModule,
      BrowserModule,
      RouterModule,
      HttpClientModule,
      CommonModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
