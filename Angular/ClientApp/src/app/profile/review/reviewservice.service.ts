import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http: HttpClient) { }

  getreviews(id:number) {
      return this.http.get<any>(`${environment.apiUrl}/api/users/` + id +'/Reviews')
  }

  postreview(id: number, review: any) {
       return this.http.post<any>(`${environment.apiUrl}/api/users/` + id + '/Reviews', review)
  }

}
