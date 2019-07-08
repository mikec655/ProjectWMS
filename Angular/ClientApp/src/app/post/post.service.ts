import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AuthenticationService } from '../authentication.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient,
    private authenticationService: AuthenticationService) { }

  getUserPosts(time: number, userId: number) {
    return this.http.get<any>(`${environment.apiUrl}/api/Users/${userId}/Posts`);
  }

  getPosts(time: number) {
    let userId = this.authenticationService.currentUserId
    return this.http.get<any>(`${environment.apiUrl}/api/Users/${userId}/Posts`);
  }

  getPost(id: number) {
    return this.http.get<any>(`${environment.apiUrl}/api/Posts/` + id);
  }

  createPost(post) {
    console.log("Creating Post");
    return this.http.post<any>(`${environment.apiUrl}/api/Posts/`, post);
  }

  editPost(id: number, post: Post) {
    return this.http.put<any>(`${environment.apiUrl}/api/Posts/` + id, post);
  }

  deletePost(id: number) {
    return this.http.delete<any>(`${environment.apiUrl}/api/Posts/` + id);
  }

  getComments(postId: number) {
    return this.http.get<any>(`${environment.apiUrl}/api/Posts/` + postId + "/comments");
  }

  getComment(postId: number, commentId: number) {
    return this.http.get<any>(`${environment.apiUrl}/api/Posts/` + postId + "/comments/" + commentId);
  }

  createComment(postId: number, comment: Comment) {
    return this.http.post<any>(`${environment.apiUrl}/api/Posts/` + postId + "/comments", comment);
  }

  editComment(postId: number, commentId: number, comment: Comment) {
    return this.http.put<any>(`${environment.apiUrl}/api/Posts/` + postId + "/comments/" + commentId, comment);
  }

  deleteComment(postId: number, commentId: number) {
    return this.http.delete<any>(`${environment.apiUrl}/api/Posts/` + postId + "/comments/" + commentId);
  }

  getInvitation(postId: number) {
    return this.http.get<any>(`${environment.apiUrl}/api/Posts/` + postId + "/invitation");
  }

  createInvitation(postId: number, invitation) {
    return this.http.post<any>(`${environment.apiUrl}/api/Posts/` + postId + "/invitation", invitation);
  }

  editInvitation(postId: number, invitation) {
    return this.http.put<any>(`${environment.apiUrl}/api/Posts/` + postId + "/invitation", invitation);
  }

  deleteInvitation(postId: number) {
    return this.http.delete<any>(`${environment.apiUrl}/api/Posts/` + postId + "/invitation");
  }

  acceptInvitation(postId: number) {
    return this.http.post<any>(`${environment.apiUrl}/api/Posts/` + postId + "/invitation/accept", {});
  }


}

export class Post {
  userFirstName: string;
  userLastName: string;
  postId: number;
  postUserId: number;
  message: string;
  postMediaId: number;
  postedAtUnix: number;
  invitationId: number;
}



export class PostComment {
  commentId: number;
  userId: number;
  username: string;
  comment: string;
}
