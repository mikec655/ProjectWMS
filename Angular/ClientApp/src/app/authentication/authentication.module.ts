import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationComponent } from './authentication.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [AuthenticationComponent],
  imports: [
      CommonModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule
  ]
})
export class AuthenticationModule { }
