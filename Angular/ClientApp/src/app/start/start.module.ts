import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileSideBarComponent } from './profile-side-bar/profile-side-bar.component';
import { MapSideBarComponent } from './map-side-bar/map-side-bar.component';
import { StartComponent } from './startContent/start.component';
import { RouterModule } from '@angular/router';
import { PostModule } from '../post/post.module';
import { AuthenticationService } from '../authentication.service';
import { MatButtonModule } from '@angular/material/button';
import { PostCardComponent } from './post-card/post-card.component';
import { MapModule } from '../map/map.module';

@NgModule({
    declarations: [ProfileSideBarComponent, MapSideBarComponent, StartComponent, PostCardComponent],
    imports: [
      CommonModule,
      PostModule,
      // MapModule,
      RouterModule.forChild([
          { path: '', component: StartComponent, canActivate: [AuthenticationService] }
      ]),
      MatButtonModule
    ],
})
export class StartModule { }
