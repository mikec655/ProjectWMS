import { Component, OnInit } from '@angular/core';
import { ProfileService, UserProfile } from './profile.service';
import { timeout, catchError } from 'rxjs/operators';
import { $ } from 'protractor';
import { environment } from '../../environments/environment';
import { AuthenticationService } from '../authentication.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { PostService } from '../post/post.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from './review/ReviewService.service';
import { UserAccount } from '../_models/useraccount';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  //template url aanpassen naar een template die opgehaald wordt door authenticatie?

  //als deze variabele: notloggedin is dan veranderd htmllayout.
  //dus als we in de service checken of het id van de ingelodepersoon gelijkt is aand de pagina dan weergeven we dit?
  //geen idee of dit handig is tho, misschien beter om 2 componenten te maken.
  public ownUserProfile = false;
  public imageSrc: any;
  public profiledescription = "profiledescriptionvariable";
  public newreviewgrade = document.getElementById("amount");
  //tijdelijke variable voor testen


  public pageProfile: UserAccount;
  private params: any;
  public user;
  public userid;
  public profileLoaded: boolean = false;

  public picture: File;
  public uploadForm: FormGroup;
  public reviewForm: FormGroup;

  public posts = []

  public result: any;

  constructor(
    private reviewservice: ReviewService,
    public profileservice: ProfileService,
    private postService: PostService,
    private formBuilder: FormBuilder,
    private httpClient: HttpClient,
    private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router) {

    this.route.params.subscribe(params => {
      this.posts = [];
      if (params != null && params['id'] != null) {
        this.userid = params['id'];
        this.ownUserProfile = this.authenticationService.currentUserId == this.userid;
      } else {
        this.userid = this.authenticationService.currentUserId;
        this.ownUserProfile = true;
      }

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

    });

    this.user = this.authenticationService.currentUserValue;
    this.postService.getUserPosts(-1, this.userid).subscribe(posts => {
      posts.sort((a, b) => b.postedAtUnix - a.postedAtUnix)
      this.posts = posts
    });
  }

  ngOnInit() {
    this.uploadForm = this.formBuilder.group({
      pic: ['']
    });

    this.reviewForm = this.formBuilder.group({
      reviewtitle: '',
      reviewtext: '',
      reviewgrade: [new Number()]
    })

    /*
    this.postService.getPosts(-1).subscribe(posts => {
      posts.sort((a, b) => b.postedAtUnix - a.postedAtUnix)
      this.posts = posts
    });*/
  }

  //hier de follow http
  follow(event, item) {
    1
    console.log(event);
    console.log(item);
  }

  onPictureError() {
    this.imageSrc = './assets/account.png';
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

  // Shorthand to get the controls of the form
  get f() { return this.uploadForm.controls; }

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

  PostReview() {
    var review = {
      "rating": this.reviewForm.controls.reviewgrade.value,
      "description": this.reviewForm.controls.reviewtext.value,
      "title": this.reviewForm.controls.reviewtitle.value,
      "ReviewUserId": this.authenticationService.currentUserId,
      "ReviewTargetId": this.userid

    }
    console.log(review);


    this.reviewservice.postreview(this.userid, review).subscribe(result => {
      console.log(result)
    },
      error => {
        if (error.status == 404) {
          this.router.navigate(['/profile']);
        }
        console.log(error);
      });
  }

}
