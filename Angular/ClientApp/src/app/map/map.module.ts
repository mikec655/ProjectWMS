import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapComponent } from './map.component';
import { RouterModule } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@NgModule({
  declarations: [MapComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: MapComponent, canActivate: [AuthenticationService] }
    ])
  ],
  exports: []
})
export class MapModule { }
