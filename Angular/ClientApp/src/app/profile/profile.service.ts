import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { AuthenticationService } from '../authentication.service';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
    public result: any;

  data: any = {};
  constructor(private http: HttpClient, private authentication: AuthenticationService) { }

  getUserProfile(id: number) {
      return this.http.get<any>(`${environment.apiUrl}/api/Users/` + id)
  }
  //return this.result;
  /*
    sub(id: number) {
        this.getUserProfile(id).subscribe(data => {
            console.log(data);
            this.data = data;
        })

        return this.data;
}
*/

  
    //tijdelijk omgezet naar any omdat ik fotos uploaden nog niet werkend heb.
  editUserProfile(id: number, profile: any) {
    if (id == null) {
      throw Error("id cannot be null!");
    }
    return this.http.put<any>(`${environment.apiUrl}/api/Users/` + id, profile)
      .subscribe(result => {
        console.log(result.token);
        if (result != null && result.token != null) {
          this.authentication.updateUser(result);
        }
      }, error => console.error(error));

  }

    /*   hier uiteindelijk een fotopost
    uploadProfilePicture() {
        return this.http.post<>
    }*/ 

  follow() {

  }

  unfollow() {

  }

}
1
export class UserProfile {
  username: string
  firstname: string
  lastname: string
  profile_picture: string
  profile_description: string
}


