import { Component, OnInit } from '@angular/core';
import { PostService } from '../../post/post.service';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {

    private posts = []

    constructor(private postService: PostService) {
        

    }

    ngOnInit() {
        console.log("MIKEs")
        this.postService.getPosts(-1).subscribe(posts => {
            console.log(posts);
            this.posts = posts;
        });
    }

    onClickPostButton() {
        console.log("Äpple")
        let post = {
            postUserId: 1,
            message: "This is a post"
        }
        this.postService.createPost(post).subscribe(x => console.log(x))
    }

 





}
