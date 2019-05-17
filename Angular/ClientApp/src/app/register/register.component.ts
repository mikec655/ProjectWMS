import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel, FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

import { MustMatch } from '../_utils/password-match.validator'

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

  constructor(private formBuilder: FormBuilder) { }

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
