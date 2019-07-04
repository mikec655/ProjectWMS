import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { CanActivate, RouterModule, Router } from '@angular/router';
import { UserAccount } from './_models/useraccount';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService implements CanActivate {

  private currentUserSubject: BehaviorSubject<UserAccount>;
  public currentUser: Observable<UserAccount>;

  protected async handleError(error: Response | any) {
    console.log(error);
    throw error;
  }

  constructor(private http: HttpClient, private router: Router) {
    this.currentUserSubject = new BehaviorSubject<UserAccount>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue() {
    return this.currentUserSubject.value;
  }

  public get currentUserId() {
    return this.currentUserValue.userId
  }

  login(username: string, password: string) {
    return this.http.post<UserAccount>(`${environment.apiUrl}/api/login`, { username, password }, { observe: 'response' })
      .pipe(map(response => {
        if (response.status == 200 && response.body != null && response.body.token != null) {
          localStorage.setItem('currentUser', JSON.stringify(response.body));
          this.currentUserSubject.next(response.body);
          this.router.navigate(["/"]);
          return response;
        }
      }));
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
    this.router.navigate(["/login"])
  }

  isLoggedIn() {
    if (this.currentUserSubject.value == null) {
      return false;
    }

    if (this.currentUserSubject.value.token == null) {
      return false;
    }

    return true;
  }

  canActivate(): boolean {
    if (this.isLoggedIn()) {
      console.log("canActivate");
      return true;
    }
    else {
      console.log("cannotActivate");
      this.router.navigate(["/login"]);
      return false;
    }
  }
}
