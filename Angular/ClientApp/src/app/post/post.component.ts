import { Component, OnInit, Input} from '@angular/core';
import { Post, PostService } from './post.service';


@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})

export class PostComponent implements OnInit {

    @Input() post = new Post()
    private comments = []
    public isCollapsed = false;

    constructor(private postService: PostService) { }
   

    ngOnInit() {
        this.postService.getComments(this.post.postId).subscribe(comments => {
            console.log(comments);
            this.comments = comments
        })
  }


}
