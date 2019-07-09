import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewComponent } from './review/review.component';
import { ProfileComponent } from './profile.component';
//import { PostComponent } from '../post/post.component';
import { RouterModule } from '@angular/router';
import { PostModule } from '../post/post.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UsersettingsComponent } from './usersettings/usersettings.component';
import { AuthenticationService } from '../authentication.service';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import {ProfileSideBarComponent} from '../../app/start/profile-side-bar/profile-side-bar.component'




@NgModule({
  declarations: [ReviewComponent, ProfileComponent, UsersettingsComponent, ProfileSideBarComponent],

  bootstrap: [UsersettingsComponent],
  imports: [
    ReactiveFormsModule,
    PostModule,
    FormsModule,
    ProfileSideBarComponent,
    NgbModule.forRoot(),
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ProfileComponent, canActivate: [AuthenticationService] },
      { path: ':id', component: ProfileComponent }
    ]),
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ]
})
export class ProfileModule { }
