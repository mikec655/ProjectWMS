import { Component } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { PWAService } from '../pwa.service';
import { Router } from '@angular/router';


@Component({
    selector: 'app-authentication-component',
    templateUrl: './authentication.component.html',
    styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent {
    loginForm: FormGroup;
    submitted: boolean;
    result: string;
    constructor(
        private formBuilder: FormBuilder,
        private authenticationService: AuthenticationService,
        public Pwa: PWAService,
        private router: Router
    ) { }

    installPwa(): void {
        this.Pwa.promptEvent.prompt();
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', [Validators.required]],
            password: ['', [Validators.required]],
        });
    }

    // Shorthand to get the controls of the form
    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.authenticationService.login(this.loginForm.controls.email.value, this.loginForm.controls.password.value)
            .subscribe(
                res => {
                    this.router.navigate(["/"])
                },
                err => {
                    console.error(err);
                }
            );
    }
}
