import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService {

    constructor(private http: HttpClient) { }

    getPosts(time: number) {
        return this.http.get<any>("api/Posts/")
    }

    getPost(id: number) {
        return this.http.get<Post>("api/Posts/" + id)
    }

    createPost(post: Post) {
        return this.http.post<any>("api/Posts/", post)
    }

    editPost(id: number, post: Post) {
        return this.http.put<any>("api/Users/" + id, post)
    }

    deletePost(id: number) {
        return this.http.delete<any>("api/Posts/" + id)
    }

    getComments(postId: number) {
        return this.http.get<Post>("api/Posts/" + postId + "/comment")
    }

    getComment(postId: number, commentId: number) {
        return this.http.get<Post>("api/Posts/" + postId + "/comment/" + commentId)
    }

    createComment(postId: number, comment: Comment) {
        return this.http.post<any>("api/Posts/" + postId + "/comment", comment)
    }

    editComment(postId: number, commentId: number, comment: Comment) {
        return this.http.put<any>("api/Posts/" + postId + "/comment/" + commentId, comment)
    }

    deleteComment(postId: number, commentId: number) {
        return this.http.delete<any>("api/Posts/" + postId + "/comment/" + commentId)
    }

}

export class Post {
    postId: number
    username: string
    userId: number
    time: number
    message: string
    comment: PostComment[]
    invitation: {
        invitationId: number
        postId: number
        time: number
        type: string
        number_of_guests: number
        guests: any
        location: any
    }
    media: string[]
}

export class PostComment {
    commentId: number
    userId: number
    username: string
    comment: string
}
