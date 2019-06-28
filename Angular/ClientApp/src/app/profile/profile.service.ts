import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  getUserProfile(id: number) {
      return this.http.get<any>(`${environment.apiUrl}/api/Users/` + id)
  }

  editUserProfile(id: number, profile: UserProfile) {
      return this.http.put<any>(`${environment.apiUrl}/api/Users/` + id, profile)
  }

  follow() {

  }

  unfollow() {

  }

}

export class UserProfile {
  username: string
  firstname: string
  lastname: string
  profile_picture: string
  profile_description: string
}


