import { Component, OnInit } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

import { PostService} from '../post.service';

import { NgModel, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

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
    guests: any;

    result: any;

    

    constructor(private modalService: NgbModal,
        private postservice: PostService, private http: HttpClient) { }

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
  
    }

    guestPost(value: any) {
        this.guests = value;
    }

    zipCode(value: any) {
        this.zipcode= value;

    }

    filePost(value: any) {
        this.zipcode = value;

    }

    titlePost(value: any) {
        this.title = value;
     
    }

    houseNumber(value: any) {
        this.housenumber = value;

    }

    postText(value: any) {
        this.message = value;
 
    }

    cityPost(value: any) {
        this.city = value;
     
    }


    //method to post post to database;
    createpost() {
        console.log(this.title);
        console.log(this.message);
        console.log(this.street);
        console.log(this.housenumber);
        console.log(this.zipcode);
        console.log(this.title);
        console.log(this.city);
        console.log(this.guests);

        var uid: number = 4;
        var postId: number = 2;
        let post = {
            postUserId: uid,
            message: this.message};

        console.log(post);
        
        
        

        //hier post object bouwen.
        this.postservice.createPost(post).subscribe(x => console.log(x));

        /*
        this.http
            .post<string>(`${environment.apiUrl}/api/Posts/`, post)
            .subscribe(result => {
                this.result = result;
                console.log(result);

            });
            */
    }


    FieldsChange() {
        console.log(this.ischecked);
        if (this.ischecked === "false") { this.ischecked = "true"; }
        else { this.ischecked = "false";}
        
    }

    ngOnInit() {
    }
}
