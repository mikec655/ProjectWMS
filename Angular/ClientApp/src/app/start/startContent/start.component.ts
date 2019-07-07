import { Component, OnInit } from '@angular/core';
import { PostService } from '../../post/post.service';
import { PWAService } from '../../pwa.service';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css']
})
export class StartComponent implements OnInit {

    private posts = []
    private comments:any 
    private post:string[] 
    

    constructor(private postService: PostService) {
        

    }

    ngOnInit() {
        console.log(this.comments.subscribe(x => console.log(x.userFirstName)))
        console.log("Äpple")
        let post = {
            postUserId: 1,
            message: "This is a post"
        }


        this.postService.createPost(post).subscribe(x => console.log(x))
        console.log("MIKEs")
        this.postService.getPosts(-1).subscribe(posts => {
            console.log(posts);
            this.posts = posts;
        });
    }

    onClickPostButton() {
        this.comments = this.getComments()
        // console.log(this.comments.subscribe(x => console.log(x.userFirstName)))
        // console.log("Äpple")
        // let post = {
        //     postUserId: 1,
        //     message: "This is a post"
        // }


        // this.postService.createPost(post).subscribe(x => console.log(x))
    }

    getComments(){
        this.comments = this.postService.getComments(1).subscribe(comments => {
            this.comments = comments as string [];

        console.log(this.comments)
        })

        this.comments.subscribe(data =>{
            this.post = data as string[]
            console.log(this.post[0])
        })

    }

}
