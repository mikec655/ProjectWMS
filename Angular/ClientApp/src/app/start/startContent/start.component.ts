import { Component, OnInit, Input } from '@angular/core';
import { PostService, Post } from '../../post/post.service';
import { PWAService } from '../../pwa.service';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {
    @Input() post = new Post()
    private posts = []
    private comments = []
    // private post:string[] 
    user;
    userid;
    

    constructor(private postService: PostService) {
        

    }

    ngOnInit() {
        this.postService.getComments(this.post.postId).subscribe(comments => {
            console.log(comments);
            this.comments = comments
        },
            error => {
            if (error.status == 404) {
                this.comments = null;
            } else {
                console.error(error);
                // this._snackBar.open(`Oopsie... Something went wrong please try again. (error code ${error.status})`, 'Oops');
            }
            });

        // console.log(this.comments.subscribe(x => console.log(x.userFirstName)))
        // console.log("Äpple")
        // let post = {
        //     postUserId: 1,
        //     message: "This is a post"
        // }


        // this.postService.createPost(post).subscribe(x => console.log(x))
        // console.log("MIKEs")
        // this.postService.getPosts(-1).subscribe(posts => {
        //     console.log(posts);
        //     this.posts = posts;
        // });
    }

    onClickPostButton() {
        console.log(this.post.message)
        // console.log(this.post.userFirstName)
        // console.log(this.post.userLastName)
        this.postService.getUserPosts(-1, this.userid).subscribe(posts => { console.log(posts); this.posts = posts });

        console.log(this.posts)
        // this.comments = this.getComments()
        // console.log(this.comments.subscribe(x => console.log(x.userFirstName)))
        // console.log("Äpple")
        // let post = {
        //     postUserId: 1,
        //     message: "This is a post"
        // }


        // this.postService.createPost(post).subscribe(x => console.log(x))
    }

    getComments(){
        // this.comments = this.postService.getComments(1).subscribe(comments => {
        //     this.comments = comments as string [];

        // console.log(this.comments)
        // })

        // this.comments.subscribe(data =>{
        //     // this.post = data as string[]
        //     // console.log(this.post[0])
        // })

    }

}
