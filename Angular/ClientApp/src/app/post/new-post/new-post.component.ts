import { Component, OnInit, Inject } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

import { PostService } from '../post.service';

import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-newpost',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
  private dialogRef: MatDialogRef<any, any>;
  public isChecked: boolean = false;
  title: any;

  message: any;
  closeResult: string;

  password: string;
  street: any;
  housenumber: any;
  zipcode: any;
  city: any;
  guests: any;

  result: any;



  constructor(private modalService: NgbModal,
    private postservice: PostService, private http: HttpClient,
    public dialog: MatDialog) { }

  openDialog() {
    this.dialogRef = this.dialog.open(NewPostDialog, {
      data: { title: '' },
      position: { top: '100px' }
    });

    this.dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    })

    /*.afterClosed().subscribe((result) => {
      this.closeResult = ` ${result}`;
      console.log(this.closeResult);

    }, (reason) => {
      this.closeResult = ` ${this.getDismissReason(reason)}`;
    });*/
  }

  onDismiss() {
    this.dialogRef.close();
  }

  //method to post post to database;
  createpost() {
    console.log(this.title);
    console.log(this.message);
    console.log(this.street);
    console.log(this.housenumber);
    console.log(this.zipcode);
    console.log(this.title);
    console.log(this.city);
    console.log(this.guests);

    var uid: number = 4;
    var postId: number = 2;
    let post = {
      postUserId: uid,
      Title: this.title,
      message: this.message,


    };

    console.log(post);




    //hier post object bouwen.
    //this.postservice.createPost(post).subscribe(x => console.log(x));


    //.post<string>(`${environment.apiUrl}/api/Users`, profile)

    this.http
      .post<any>(`${environment.apiUrl}/api/Posts/`, post)
      .subscribe(result => {
        this.result = result;
        console.log(result);

      });
    console.log("after Post");

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

  ngOnInit() {
  }

  onDismiss(): void {
    this.dialogRef.close();
  }
}
