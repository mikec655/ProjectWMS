import { Component, OnInit } from '@angular/core';
import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MustMatch } from '../_utils/password-match.validator'
import { AuthenticationService } from '../authentication.service';
import { HttpClient } from 'selenium-webdriver/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  email: String;
  registerForm: FormGroup;
  profileForm: FormGroup;
  submitted = false;
  result: any;
  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private http: HttpClient) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      repeatPassword: ['', [Validators.required]]
    }, {
        validator: MustMatch('password', 'repeatPassword')
    });
  }

  onClick() {
    this.email = "hoi";
  }

  // Shorthand to get the controls of the form
  get f() { return this.registerForm.controls; }

  onSubmit() {
    console.log(this.registerForm.controls.password.errors)
    this.submitted = true;
    // TODO: Use EventEmitter with form value
    console.warn(this.registerForm.value);
    var test = {
      "email": this.registerForm.controls.password.value,
      "password": this.registerForm.controls.email.value
    }
    let data = JSON.stringify(test);
    this.http
      .post<string>('api/SampleData/Register', test)
      .subscribe(result => { this.result = result; console.log(result); });
  }

}

export class Register {

  constructor(
    public id: number,
    public email: NgModel,
    public password: NgModel,
    public repeatPassword: NgModel
  ) { }

}
