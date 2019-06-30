import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import * as bootstrap from '@ng-bootstrap/ng-bootstrap';

import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MustMatch } from '../../_utils/password-match.validator'
import { AuthenticationService } from '../../authentication.service';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { ProfileService } from '../profile.service';
//import * as $ from 'jquery';




@Component({
  selector: 'app-usersettings',
  templateUrl: './usersettings.component.html',
    styleUrls: ['./usersettings.component.css']
})
export class UsersettingsComponent implements OnInit {
  message: string;
  closeResult: string;
  firstname: string;
  lastname: string;
    password: string;
    street: string;
    housenumber: string;
    zipcode: string;
    date;

    user;
    userid;

    profileForm: FormGroup;
    result: any;
    submitted = false;

    constructor(
        private modalService: NgbModal,
        private formBuilder: FormBuilder,
        private authenticationService: AuthenticationService,
        private profileservice: ProfileService,
        private http: HttpClient) { }


    ngOnInit() {
        this.profileForm = this.formBuilder.group({
            firstname: ['', [Validators.required]],
            lastname: ['', [Validators.required]],
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
            })

        //get userobject and id for posts.
        this.user = this.authenticationService.currentUserValue;
        this.userid = this.user.userId //this.authenticationService.currentUserId();

    }

    get f() { return this.profileForm.controls; }
    //hier nog uid ophalen
    onSubmit() {
        this.submitted = true;
        var profile = {
            "firstname": this.profileForm.controls.firstname.value,
            "lastname": this.profileForm.controls.lastname.value,
            "street": this.profileForm.controls.street.value,
            "number": this.profileForm.controls.number.value,
            "zipCode": this.profileForm.controls.zipCode.value,
            "city": this.profileForm.controls.city.value,
            "username": this.profileForm.controls.email.value,
            "password": this.profileForm.controls.password.value,
            "profileDescription": this.profileForm.controls.profileDescription.value
        }

        //post new usersettings
        this.profileservice.editUserProfile(this.userid, profile).subscribe(result => {
            this.result = result;
            console.log(result);

        });
    }

//methods for opening and closing the modal.
  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = ` ${result}`;
      console.log(this.closeResult);
      
    }, (reason) => {
      this.closeResult = ` ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'Closed pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'Closed clicking on a backdrop';
    } else {
      return ` ${reason}`;
    }
  }

  //submit function
  close() {
    
    //hier iets mee doen vanuit response van database ofzo?
    if (this.firstname == null || this.lastname == null || this.password == null || this.date == null) {
      this.message = "saving failed";
    }
    else {
      //hier pushen naar db
      console.log(this.firstname + "-" + this.lastname + "-" + this.password + "-" + this.date);
      this.message = "saving succesfull";
      //shijt jquery werkt niet $('#content').modal('hide'); dus kan hem nniet automatisch sluiten
    }
  }

 


  }
  

