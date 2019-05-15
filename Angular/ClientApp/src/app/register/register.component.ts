import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model = new Register(0, '', '', '');

  constructor() { }

  ngOnInit() {
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
