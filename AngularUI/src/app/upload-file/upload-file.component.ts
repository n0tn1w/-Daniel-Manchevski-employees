import {Component, OnInit} from '@angular/core';
import {AppServiceService} from "../app-service.service";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent implements OnInit {

  fileToUpload: File;
  formGroup: FormGroup;

  constructor(private appService: AppServiceService,
              private router: Router) {
  }

  ngOnInit(): void {
    this.appService.getFileData().subscribe(res => {
      console.log(res);
    });
  }

  handleFileInput(event: any) {
    const file: File = event.target.files[0];
    this.fileToUpload = file;
  }

  uploadFileToActivity() {
    const formData = new FormData();
    formData.append('file', this.fileToUpload, this.fileToUpload.name);

    this.appService.postUploadFile(formData).subscribe(data => {
      this.router.navigate(['uploaded']);
    }, error => {
      console.log(error);
    });
  }
}
