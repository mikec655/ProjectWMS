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
  public profileview = 'loggedin';
  public ownUserProfile = false;
  public imageSrc: any = environment.apiUrl + '/api/Media/' + this.authenticationService.currentUserValue.userMediaId;

  public username = "usernamevariable";
  public profiledescription = "profiledescriptionvariable";
  public newreviewgrade = document.getElementById("amount");
  //tijdelijke variable voor testen
  public posttekst = "postteskhier"

  public pageProfile: any;
  private params: any;
  user;
  userid;

  public picture: File;
  public uploadForm: FormGroup;

  public posts = []

  public result: any;

  constructor(
    public profileservice: ProfileService,
    private postService: PostService,
    private formBuilder: FormBuilder,
    private httpClient: HttpClient,
    private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router) {

    this.route.params.subscribe(params => {
      if (params != null && params['id'] != null) {
        this.userid = params['id'];
        this.ownUserProfile = false;
      } else {
        this.userid = this.authenticationService.currentUserId;
        this.ownUserProfile = true;
      }
      //hier roep ik iets aan om een userobject te halen,
      this.profileservice.getUserProfile(this.userid).subscribe(data => {
        this.pageProfile = data;
        this.postService.getUserPosts(-1, this.userid).subscribe(posts => { this.posts = posts });
      },
        error => {
          if (error.status == 404) {
            this.router.navigate(['/profile']);
          }
        });
    });
    console.log("profilepage id=" + this.userid);
    this.user = this.authenticationService.currentUserValue;
  }

  ngOnInit() {
    this.uploadForm = this.formBuilder.group({
      pic: ['']
    });

    this.posttekst = "5AlCI9UD6J5AO4gtgscMo86tsGcouOG dsfsaf sdfsfdsf sss  sss dsfsd sdfsd fsdfs sfdsdfs l5i2tnK0KoqpZHV0AEqgjC7MbKnfm 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"
    this.profiledescription = "profieltekst hier;"


    this.pageProfile = this.profileservice.data;

    this.username = this.pageProfile.firstname;

    this.postService.getPosts(-1).subscribe(posts => {
      posts.sort((a, b) => b.postedAtUnix - a.postedAtUnix)
      this.posts = posts
    });
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

  print() {
    console.log("print dit na de print van account data");
    console.log(this.pageProfile);
    console.log(this.pageProfile);
  }

  uploadProfilePicture() {
    const formData = new FormData();

    formData.append('file', this.picture);


    this.httpClient.post<any>(`${environment.apiUrl}/api/Media/`, formData).subscribe(result => {
      this.result = result;
      console.log(result);
      this.profileservice.editUserProfile(this.user.userid, { 'userId': this.user.userId, 'userMediaId': result.mediaId });
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
}
