import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewComponent } from './review/review.component';
import { ProfileComponent } from './profile.component';
import { PostComponent } from '../post/post.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ReviewComponent, ProfileComponent, PostComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ProfileComponent, /*canActivate: [AuthGuardService]*/ }
    ])
  ]
})
export class ProfileModule { }
