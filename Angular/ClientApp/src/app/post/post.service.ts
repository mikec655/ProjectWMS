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

    createPost(post) {
        return this.http.post<any>("api/Posts/", post)
    }

    editPost(id: number, post: Post) {
        return this.http.put<any>("api/Posts/" + id, post)
    }

    deletePost(id: number) {
        return this.http.delete<any>("api/Posts/" + id)
    }

    getComments(postId: number) {
        return this.http.get<any>("api/Posts/" + postId + "/comments")
    }

    getComment(postId: number, commentId: number) {
        return this.http.get<any>("api/Posts/" + postId + "/comments/" + commentId)
    }

    createComment(postId: number, comment: Comment) {
        return this.http.post<any>("api/Posts/" + postId + "/comments", comment)
    }

    editComment(postId: number, commentId: number, comment: Comment) {
        return this.http.put<any>("api/Posts/" + postId + "/comments/" + commentId, comment)
    }

    deleteComment(postId: number, commentId: number) {
        return this.http.delete<any>("api/Posts/" + postId + "/comments/" + commentId)
    }

}

export class Post {
    postId:number
    postUserId: number
    message: string
}

export class PostComment {
    commentId: number
    userId: number
    username: string
    comment: string
}
