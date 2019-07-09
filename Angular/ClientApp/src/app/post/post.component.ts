import { Component, OnInit, Input } from '@angular/core';
import { PostService } from './post.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from '../../environments/environment';
import { error } from '@angular/compiler/src/util';
import { Invitation } from '../_models/invitation';
import { AuthenticationService } from '../authentication.service';
import { Post } from '../_models/post';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent {
  @Input() post = new Post()
  @Input('userMediaId') userMediaId: number = this.post.postUserMediaId;
  public invitation: Invitation;
  public comments = [];
  public isCollapsed = true;
  public imageSrc: any = environment.apiUrl + '/api/Media/' + this.post.postMediaId;
  public commentsReceived = false;
  public timeString: string;
  public invitationTimeString: string;
  public acceptedInvite: boolean;
  public canAccept: boolean;
  public commentInput;
  public userImageSrc;

  constructor(
    private postService: PostService,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService
  ) {}


  ngOnInit() {
    this.userImageSrc = this.userMediaId == null || this.userMediaId == 0 ? './assets/account.png' : environment.apiUrl + '/api/Media/' + this.userMediaId;
    console.log(this.post.comments);
    if (this.post.comments > 0) {
      this.postService.getComments(this.post.postId).subscribe(comments => {
        comments.sort((a, b) => b.postedAtUnix - a.postedAtUnix);
        comments.forEach(comment => comment.postedAtUnix = this.timeToString(comment.postedAtUnix));
        this.comments = comments;
        this.commentsReceived = true;
      },
        error => {
          this.commentsReceived = false;
          if (error.status != 404) {
            console.error(error);
            this._snackBar.open(`Oopsie... Something went wrong fetching comments. (error code ${error.status})`, 'Oops');
          }
        });
    } else {
      this.commentsReceived = false;
    }
    if (this.post.invitationId) {
      this.postService.getInvitation(this.post.postId).subscribe(invitation => {
        console.log(invitation.invitationDateUnix);
        this.invitationTimeString = this.timeToString(invitation.invitationDateUnix);
        const userId = this._authenticationService.currentUserId;
        this.acceptedInvite = invitation.guests.findIndex(p => p.guestUserId == userId) != -1;
        this.canAccept = this.acceptedInvite || invitation.guests.length >= invitation.numberOfGuests;
        this.invitation = invitation;
      });
    }
    console.log(this.post.postedAtUnix);
    this.timeString = this.timeToString(this.post.postedAtUnix);
  }

  acceptInvitation(id: number) {
    this.postService.acceptInvitation(id).subscribe(r => console.log(r), error => console.log(error));
    this.acceptedInvite = true;
  }

  onPictureError() {
    this.imageSrc = './assets/account.png';
  }

  postComment() {
    console.log(this.commentInput)
    this.postService.createComment(this.post.postId, {
      content: this.commentInput,
      commentUserId: this._authenticationService.currentUserId
    }).subscribe(e => console.log(e))
  }

  timeToString(timeStamp: number) {
    let time = new Date(timeStamp);
    let currentTime = new Date(Date.now());
    let yesterdayTime = new Date(Date.now() - 24 * 60 * 60);
    yesterdayTime.setMilliseconds(0);
    yesterdayTime.setSeconds(0);
    yesterdayTime.setMinutes(0);
    yesterdayTime.setHours(0);

    let timeDiff = (currentTime.getTime() - time.getTime()) / 1000;

    if (timeDiff > 0) {
      return this.timestamp(timeStamp);
    } else if (timeDiff < 60 * 60) {
      return Math.round(timeDiff / 60) + " minutes ago";
    } else if (timeDiff < 24 * 60 * 60) {
      return Math.round(timeDiff / (60 * 60)) + " hours ago";
    } else if (time.getTime() > yesterdayTime.getTime()) {
      return "yesterday";
    } else {
      return this.timestamp(timeStamp);
    }
  }

  timestamp(time: number) {
    const monthNames = ["januari", "februari", "maart", "april", "mei", "juni",
      "juli", "augustus", "september", "oktober", "november", "december"
    ];
    var dt = new Date(time);
    var y = dt.getFullYear();
    var mth = dt.getMonth();
    var d = "0" + dt.getDate();
    var hr = "0" + dt.getHours();
    var m = "0" + dt.getMinutes();

    return d.substr(-2) + ' ' + monthNames[mth] + ' ' + y + ' ' +
      hr.substr(-2) + ':' + m.substr(-2);
  }

}

