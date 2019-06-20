import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  getUserProfile(): UserProfile {
    this.http.post<string>("api/", "");
    return null;
  }
}

export class UserProfile {
  id: number
  username: string
  firstname: string
  lastname: string
  profile_picture: string
  profile_description: string
}


