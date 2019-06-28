import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import * as bootstrap from '@ng-bootstrap/ng-bootstrap';
//import * as $ from 'jquery';
declare var $: any;



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

  constructor(private modalService: NgbModal) { }

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

  ngOnInit() {
  }
  
}
