import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewComponent } from './review/review.component';
import { ProfileComponent } from './profile.component';
//import { PostComponent } from '../post/post.component';
import { RouterModule } from '@angular/router';
import { PostModule } from '../post/post.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { UsersettingsComponent } from './usersettings/usersettings.component';
import { AuthenticationService } from '../authentication.service';



@NgModule({
  declarations: [ReviewComponent, ProfileComponent, UsersettingsComponent],
  
  bootstrap: [UsersettingsComponent],
  imports: [
    PostModule,
    FormsModule,
    NgbModule.forRoot(),
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ProfileComponent, canActivate: [AuthenticationService] }
    ])
  ]
})
export class ProfileModule { }
