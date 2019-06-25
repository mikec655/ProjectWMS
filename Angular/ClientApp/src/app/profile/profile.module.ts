import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewComponent } from './review/review.component';
import { ProfileComponent } from './profile.component';
//import { PostComponent } from '../post/post.component';
import { RouterModule } from '@angular/router';
import { PostModule } from '../post/post.module';

@NgModule({
  declarations: [ReviewComponent, ProfileComponent],
  imports: [
    PostModule,
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ProfileComponent, /*canActivate: [AuthGuardService]*/ }
    ])
  ]
})
export class ProfileModule { }
