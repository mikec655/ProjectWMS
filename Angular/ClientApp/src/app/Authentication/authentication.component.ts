import { Component } from '@angular/core';
import { FormBuilder, Validators, FormGroup, AbstractControl } from '@angular/forms';
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
  submitted: boolean = false;
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

  getErrorMessage(control: AbstractControl) {
    return control.hasError('invalid') ? 'Invalid email/password!' : control.hasError('required') ? 'You must enter a value' : '';
  }

  // Shorthand to get the controls of the form
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    if (!this.loginForm.valid) {
      return;
    }

    this.authenticationService.login(this.f.email.value, this.f.password.value)
      .subscribe(
        res => {
          this.router.navigate(["/"])
        },
        err => {
          if (err.error != null && err.error.code == 1) {
            this.f.email.setErrors({ 'invalid': true });
            this.f.password.setErrors({ 'invalid': true });
            return;
          }
          console.error(err);
        }
      );
  }
}
