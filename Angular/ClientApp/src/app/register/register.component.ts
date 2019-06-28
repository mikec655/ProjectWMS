import { Component, OnInit } from '@angular/core';
import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MustMatch } from '../_utils/password-match.validator'
import { AuthenticationService } from '../authentication.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Router } from '@angular/router';

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
    private http: HttpClient,
    private router: Router) { }

  ngOnInit() {
      this.registerForm = this.formBuilder.group({
          firstname: ['', [Validators.required]],
          lastname: ['', [Validators.required]],
          gender: ['', [Validators.required]],
          birthDate: ['', [Validators.required]],
          street: ['', [Validators.required]],
          number: ['', [Validators.required]],
          zipCode: ['', [Validators.required]],
          city: ['', [Validators.required]],
          email: ['', [Validators.required]],
          password: ['', [Validators.required, Validators.minLength(6)]],
          repeatPassword: ['', [Validators.required]],
          profileDescription: ['', [Validators.required]]
    }, {
        validator: MustMatch('password', 'repeatPassword')
    });
  }

  // Shorthand to get the controls of the form
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;
       var profile = {
          "firstname": this.registerForm.controls.firstname.value,
          "lastname": this.registerForm.controls.lastname.value,
          "gender": this.registerForm.controls.gender.value,
          "birthDateUnix": Math.round(new Date(this.registerForm.controls.birthDate.value).getTime()),
          "street": this.registerForm.controls.street.value,
          "number": this.registerForm.controls.number.value,
          "zipCode": this.registerForm.controls.zipCode.value,
          "city": this.registerForm.controls.city.value,
          "username": this.registerForm.controls.email.value,
          "password": this.registerForm.controls.password.value,
          "profileDescription": this.registerForm.controls.profileDescription.value
    }
      this.http
        .post<string>(`${environment.apiUrl}/api/Users`, profile)
          .subscribe(result => {
              this.result = result;
              console.log(result);
              this.router.navigate(["/login"]);
          });
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
