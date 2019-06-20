import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileSideBarComponent } from './profile-side-bar/profile-side-bar.component';
import { MapSideBarComponent } from './map-side-bar/map-side-bar.component';
import { StartComponent } from './start/start.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ProfileSideBarComponent, MapSideBarComponent, StartComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: StartComponent, /*canActivate: [AuthGuardService]*/ }
    ])
  ]
})
export class StartModule { }
