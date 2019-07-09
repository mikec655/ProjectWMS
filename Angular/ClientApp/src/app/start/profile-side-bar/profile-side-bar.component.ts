import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../authentication.service';
import { environment } from '../../../environments/environment';
import { UserAccount } from '../../_models/useraccount';
import { ProfileService } from '../../profile/profile.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../../post/post.service';
import { post } from 'selenium-webdriver/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-profile-side-bar',
  templateUrl: './profile-side-bar.component.html',
  styleUrls: ['./profile-side-bar.component.css']
})
export class ProfileSideBarComponent implements OnInit {
  public pageProfile: UserAccount;
  public user;
  public userid;
  public posts = []
  public picture: File;
  public uploadForm: FormGroup;
  public reviewForm: FormGroup;
  public result: any;
  public imageSrc: any;
  public profileLoaded: boolean = false;
  // public imageSrc: any = environment.apiUrl + '/api/Media/' + this.authenticationService.currentUserValue.userMediaId;
  constructor(private authenticationService: AuthenticationService,  
    public profileservice: ProfileService,
    private postService: PostService,
    private httpClient: HttpClient,
    private router: Router) { }

  ngOnInit() {
    // console.log()

        //hier roep ik iets aan om een userobject te halen,
        this.profileservice.getUserProfile(this.userid).subscribe(profile => {
          this.pageProfile = profile;
          this.profileLoaded = true;
          this.imageSrc = profile.userMediaId == null || profile.userMediaId == 0 ? "./assets/account.png" : environment.apiUrl + '/api/Media/' + profile.userMediaId;
        },
          error => {
            if (error.status == 404) {
              this.router.navigate(['/profile']);
            }
            this.profileLoaded = true;
            this.imageSrc = "./assets/account.png";
            console.log(error);
          });

          this.user = this.authenticationService.currentUserValue;
          this.postService.getUserPosts(-1, this.userid).subscribe(posts => {
            posts.sort((a, b) => b.postedAtUnix - a.postedAtUnix)
            this.posts = posts
          });
          console.log(
            this.user
          )
  }


  
  uploadProfilePicture() {
    const formData = new FormData();

    formData.append('file', this.picture);


    this.httpClient.post<any>(`${environment.apiUrl}/api/Media/`, formData).subscribe(result => {
      this.result = result;
      console.log(result);
      this.profileservice.editUserProfile(this.authenticationService.currentUserId, { 'userId': this.authenticationService.currentUserId, 'userMediaId': result.mediaId });
      this.imageSrc = environment.apiUrl + '/api/Media/' + result.mediaId;
    });
  }

  getPhoto(event) {
    if (event.target.files.length > 0) {
      this.picture = event.target.files[0];
      console.log(this.picture.size);
      if (this.picture.size < 10000000) {
        this.uploadProfilePicture();
      } else {
        this.uploadForm.controls.pic.setErrors({ 'size': true });
      }
    }
  }


  onPictureError() {
    this.imageSrc = "./assets/account.png";
  }

}
