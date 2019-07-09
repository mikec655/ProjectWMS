import { Comment } from '@angular/compiler';

export class Post {
  public postId?: number;
  public postUserId?: number;
  public invitationId?: number;
  public userFirstName?: string;
  public userLastName?: string;
  public postedAtUnix?: number;
  public title: string;
  public message: string;
  public postMediaId?: number;
  public postUserMediaId?: number;
  public comments?: number;
}
