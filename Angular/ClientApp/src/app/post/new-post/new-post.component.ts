import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-newpost',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
    public ischecked: string = "false";
    title: any;

    message: any;
    closeResult: string;

    password: string;
    street: any;
    housenumber: any;
    zipcode: any;
    city: any;


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


    streetPost(value: any) {
        this.street = value;
        console.log(1)
        console.log(value)
    }


    zipCode(value: any) {
        this.zipcode= value;
        console.log(2)
        console.log(value)
    }

    filePost(value: any) {
        this.zipcode = value;
        console.log(3)
        console.log(value)
    }

    titlePost(value: any) {
        this.title = value;
        console.log(this.title)
    }

    houseNumber(value: any) {
        this.housenumber = value;
        console.log(4)
        console.log(this.housenumber)
        console.log(value)
    }

    postText(value: any) {
        this.message = value;
        console.log(5)
        console.log(value)
    }

    cityPost(value: any) {
        this.city = value;
        console.log(this.city);
    }


    //method to post post to database;
    createpost() {
        console.log(1938293)
        console.log(this.message);
        console.log(this.street);
        console.log(this.housenumber);
        console.log(this.zipcode);
        console.log(this.title);
        console.log(this.city);


    }


    FieldsChange() {
        console.log(this.ischecked);
        if (this.ischecked === "false") { this.ischecked = "true"; }
        else { this.ischecked = "false";}
        
    }

    ngOnInit() {
    }
}
