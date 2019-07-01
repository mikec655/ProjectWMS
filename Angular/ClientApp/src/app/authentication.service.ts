import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { User } from './_models/user';
import { CanActivate, RouterModule, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService implements CanActivate {

    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    protected async handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = await error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
    }

    constructor(private http: HttpClient, private router: Router) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue() {
        return this.currentUserSubject.value;
    }

    public get currentUserId() {
        return this.currentUserValue.userId
    }

    login(username: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}/api/login`, { username, password })
            .pipe(map(user => {
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user)
                this.router.navigate(["/"])
                return user;
            }), catchError(this.handleError));
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
        if (this.isLoggedIn()) return true
        else {
            this.router.navigate(["/login"])
            return false
        }
    }
}
