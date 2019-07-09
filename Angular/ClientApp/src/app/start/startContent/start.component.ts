import { Component, OnInit, Input } from '@angular/core';
import { PostService} from '../../post/post.service';
import { Post } from '../../_models/post';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {

    public posts = []
   
    constructor(private postService: PostService) { }

    ngOnInit() {
        this.postService.getPosts(-1).subscribe(posts => {
            console.log(posts);
            this.posts = posts
        },
        error => {
        if (error.status == 404) {
            this.posts = null;
        } else {
            console.error(error);
               
        }
        }); 
    }

}
