import { Component, OnInit, Inject } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

import { PostService } from '../post.service';

import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AuthenticationService } from '../../authentication.service';

@Component({
  selector: 'app-newpost',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
  private dialogRef: MatDialogRef<any, any>;
  public isChecked: boolean = false;

  constructor(private modalService: NgbModal,
    private postservice: PostService,
    private http: HttpClient,
    public dialog: MatDialog,
    private _authenticationService: AuthenticationService
  ) { }

  openDialog() {
    this.dialogRef = this.dialog.open(NewPostDialog, {
      data: { title: '' },
      position: { top: '100px' }
    });

    this.dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result != null) {
        let post = {
          "title": result.title,
          "message": result.message
        }
      }
    })

  }

  //method to post post to database;
  createpost() {
    var uid: number = 4;
    var postId: number = 2;

    // Move this to the 
    /*this.http
      .post<any>(`${environment.apiUrl}/api/Posts/`, post)
      .subscribe(result => {
        this.result = result;
        console.log(result);

      });*/

  }


  FieldsChange() {
    console.log(this.isChecked);
    this.isChecked = !this.isChecked;

  }

  ngOnInit() {
  }
}

export interface DialogData {
  title: string;
  content: string;
  useAddress: boolean;
  street: string;
  houseNumber: string;
  zipCode: string;
  city: string;
  file: any
}

@Component({
  selector: 'new-post-dialog',
  templateUrl: './new-post-dialog.html',
  styleUrls: ['./new-post-dialog.css']
})
export class NewPostDialog {
  newPostForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<NewPostDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  onDismiss(): void {
    this.dialogRef.close();
  }

  processFile(event): void {
    this.data.file = event.target.files[0];
  }
}
