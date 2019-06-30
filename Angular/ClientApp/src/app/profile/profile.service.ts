import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
    public result: any;

    data: any = {};
  constructor(private http: HttpClient) { }

  getUserProfile(id: number) {
      return this.http.get<any>(`${environment.apiUrl}/api/Users/` + id)
  }
    //return this.result; */
    sub() {
        this.getUserProfile(4).subscribe(data => {
            console.log(data);
            this.data = data;
        })

        return this.data;
    }

  
    //tijdelijk omgezet naar any omdat ik fotos uploaden nog niet werkend heb.
  editUserProfile(id: number, profile:any) {
      return this.http.put<any>(`${environment.apiUrl}/api/Users/` + id, profile)

  }

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


