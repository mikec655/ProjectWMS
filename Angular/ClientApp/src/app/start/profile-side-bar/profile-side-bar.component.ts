import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../authentication.service';
import { environment } from '../../../environments/environment';


@Component({
  selector: 'app-profile-side-bar',
  templateUrl: './profile-side-bar.component.html',
  styleUrls: ['./profile-side-bar.component.css']
})
export class ProfileSideBarComponent implements OnInit {
  public imageSrc: any = environment.apiUrl + '/api/Media/' + this.authenticationService.currentUserValue.userMediaId;
  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
  }

}
