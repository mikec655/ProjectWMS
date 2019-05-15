import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  email: String;
  model = new Register(0, '', '', '');

  constructor() { }

  ngOnInit() {
  }

  onClick() {
    this.email = "hoi";
}

}

export class Register {

  constructor(
    public id: number,
    public email: string,
    public password: string,
    public repeatPassword: string
  ) { }

}
