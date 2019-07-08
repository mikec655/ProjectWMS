import { Component, OnInit, Input } from '@angular/core';
import { Post, PostService } from './post.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from '../../environments/environment';
import { error } from '@angular/compiler/src/util';
import { AuthenticationService } from '../authentication.service';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent {
  @Input() post = new Post()
  public invitation;
  public comments = [];
  public isCollapsed = true;
  public imageSrc: any = environment.apiUrl + '/api/Media/' + this.post.postMediaId;
  public commentsReceived = false;
  public commentInput;
  public timeString;

  constructor(private postService: PostService,
    private authenticationService: AuthenticationService,
    private _snackBar: MatSnackBar) { }


  ngOnInit() {
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
    if (this.post.invitationId) {
      this.postService.getInvitation(this.post.postId).subscribe(invitation => {
        invitation.invitationDateUnix = this.timeToString(invitation.invitationDateUnix);
        this.invitation = invitation;
      });
    }

    this.timeString = this.timeToString(this.post.postedAtUnix);
  }

  acceptInvitation(id: number) {
    this.postService.acceptInvitation(id).subscribe(r => console.log(r), error => console.log(error));
  }

  postComment() {
    console.log(this.commentInput)
    this.postService.createComment(this.post.postId, {
      content: this.commentInput,
      commentUserId: this.authenticationService.currentUserId
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

    if (timeDiff < 60 * 60) {
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

