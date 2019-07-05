import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileSideBarComponent } from './profile-side-bar/profile-side-bar.component';
import { MapSideBarComponent } from './map-side-bar/map-side-bar.component';
import { StartComponent } from './startContent/start.component';
import { RouterModule } from '@angular/router';
import { PostModule } from '../post/post.module';
import { AuthenticationService } from '../authentication.service';

@NgModule({
    declarations: [ProfileSideBarComponent, MapSideBarComponent, StartComponent],
    imports: [
        CommonModule,
        PostModule,
        RouterModule.forChild([
            { path: '', component: StartComponent, canActivate: [AuthenticationService] }
        ])
    ],
})
export class StartModule { }
