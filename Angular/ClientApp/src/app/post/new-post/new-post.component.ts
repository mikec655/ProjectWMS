import { Component, OnInit, Inject } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

import { PostService } from '../post.service';

import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AuthenticationService } from '../../authentication.service';
import { Media } from '../../_models/media';
import { Post } from '../../_models/post';
import { map } from 'rxjs/operators';
import { Invitation } from '../../_models/invitation';
import { UserAccount } from '../../_models/useraccount';

@Component({
  selector: 'app-newpost',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
  private dialogRef: MatDialogRef<NewPostDialog, DialogData>;
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
      this.createPost(result);
    })

  }

  async createPost(result: DialogData) {
    if (result != null) {
      let post: Post = {
        "title": result.title,
        "message": result.content
      };

      if (result.fileId != null) {
        post.postMediaId = result.fileId;
      }
      else if (result.fileUpload != null) {
        const media: Media = await result.fileUpload;
        post.postMediaId = media.mediaId;
      }

      post = await this.http.post<Post>(`${environment.apiUrl}/api/Posts/`, post).toPromise();
      console.log(post);

      if (result.createInvitation) {
        let invitation: Invitation = {
          "invitationPostId": post.postId,
          "numberOfGuests": result.numGuests
        };
        if (result.useAddress) {
          let user: UserAccount = this._authenticationService.currentUserValue;
          invitation.address = user.street;
          invitation.number = user.number;
          invitation.zipCode = user.zipCode;
          invitation.city = user.city;
        } else {
          invitation.address = result.street;
          invitation.number = result.houseNumber;
          invitation.city = result.city;
          invitation.zipCode = result.zipCode;
        }

        this.http.post(`${environment.apiUrl}/api/Posts/${post.postId}/Invitation`, invitation).subscribe(result => {
          console.log(result);
        }
        );
      }
    }
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
    this.isChecked = !this.isChecked;
  }

  ngOnInit() {
  }
}

export interface DialogData {
  title: string;
  content: string;
  createInvitation: boolean;
  useAddress: boolean;
  street: string;
  houseNumber: string;
  zipCode: string;
  city: string;
  file: any;
  fileId: number;
  fileUpload: Promise<any>;
  numGuests: number;
}

@Component({
  selector: 'new-post-dialog',
  templateUrl: './new-post-dialog.html',
  styleUrls: ['./new-post-dialog.css']
})
export class NewPostDialog {
  newPostForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<NewPostDialog, DialogData>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private httpClient: HttpClient
  ) { }

  onDismiss(): void {
    this.dialogRef.close();
    if (this.data.fileId != null) {
      this.httpClient.delete(`${environment.apiUrl}/api/Media/${this.data.fileId}`).toPromise();
    }
  }

  async processFile(event): Promise<void> {
    if (this.data.fileUpload != null) {
      await this.data.fileUpload;
    }
    this.data.file = event.target.files[0];

    const formData = new FormData();

    formData.append('file', this.data.file);

    console.log("fileId: " + this.data.fileId);
    if (this.data.fileId == null) {
      this.data.fileUpload = this.httpClient.post<Media>(`${environment.apiUrl}/api/Media/`, formData).pipe(map(
        result => {
          this.data.fileId = result.mediaId;
          console.log(result);
          return result;
        }
      )).toPromise();
    } else {
      this.data.fileUpload = this.httpClient.put(`${environment.apiUrl}/api/Media/${this.data.fileId}`, formData).toPromise();
    }
  }
}
