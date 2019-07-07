import { Component, OnInit, Input } from '@angular/core';
import { Post, PostService } from './post.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit {

  @Input() post = new Post()
  private comments = []
  public isCollapsed = true;
  public imageSrc: any = environment.apiUrl + '/api/Media/' + this.post.postMediaId;

  constructor(private postService: PostService, private _snackBar: MatSnackBar) { }


  ngOnInit() {
    this.imageSrc = 
    this.postService.getComments(this.post.postId).subscribe(comments => {
      console.log(comments);
      this.comments = comments
    },
      error => {
        if (error.status == 404) {
          this.comments = null;
        } else {
          console.error(error);
          this._snackBar.open(`Oopsie... Something went wrong please try again. (error code ${error.status})`, 'Oops');
        }
      });
  }


}
