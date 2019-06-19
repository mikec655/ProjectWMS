import { Component } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';


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
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

    // Shorthand to get the controls of the form
  get f() { return this.loginForm.controls; }

  onSubmit() {
    console.log(this.loginForm.controls.password.errors)
    this.submitted = true;
    // TODO: Use EventEmitter with form value
    console.warn(this.loginForm.value);
    var test = {
      "email": this.loginForm.controls.password.value,
      "password": this.loginForm.controls.email.value
    }
    let data = JSON.stringify(test);
    this.http
      .post<string>('api/SampleData/Login', test)
      .subscribe(result => { this.result = result; console.log(result); });
  }
}
