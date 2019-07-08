import { Component, OnInit } from '@angular/core';
import { ReviewService } from './ReviewService.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../authentication.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  private userid: number;
  private reviews = [];
  constructor(
    private reviewservice: ReviewService,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
  ) {

    this.route.params.subscribe(params => {
      if (params != null && params['id'] != null) {
        this.userid = params['id'];
      }
      else {
        this.userid = this.authenticationService.currentUserId;
      }
    });

    this.reviewservice.getreviews(this.userid).subscribe(reviews => {
      this.reviews = reviews
      console.log("review object :");
      console.log(this.reviews);
    },
      error => {
        if (error.status == 404) {
          this.reviews = null;
        } else {
          console.error("gettingreviews failed :"+ error);
        }
      });
  }

  

  ngOnInit() {
    //testfuncties
    //this.printuser()
    setTimeout(() => { 
      this.printreviews()
    }, 3000);
    this.printreviews()
  }

  printuser() {
    console.log(this.userid);
  }

  printreviews() {
    //console.log(this.reviews[0].reviewId);
  }
}
