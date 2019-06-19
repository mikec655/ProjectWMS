import { Component, OnInit } from '@angular/core';
import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MustMatch } from '../_utils/password-match.validator'
import { AuthenticationService } from '../authentication.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  username: String;
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
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      repeatPassword: ['', [Validators.required]]
    }, {
        validator: MustMatch('password', 'repeatPassword')
    });
  }

  onClick() {
    this.username = "hoi";
  }

  // Shorthand to get the controls of the form
  get f() { return this.registerForm.controls; }

  onSubmit() {
    console.log(this.registerForm.controls.password.errors)
    this.submitted = true;
    // TODO: Use EventEmitter with form value
    console.warn(this.registerForm.value);
    var test = {
      "username": this.registerForm.controls.email.value,
      "password": this.registerForm.controls.password.value
    }
    let data = JSON.stringify(test);
    this.http
      .post<string>('api/Users', test)
      .subscribe(result => { this.result = result; console.log(result); });
  }

}

export class Register {

  constructor(
    public id: number,
    public username: NgModel,
    public password: NgModel,
    public repeatPassword: NgModel
  ) { }

}
