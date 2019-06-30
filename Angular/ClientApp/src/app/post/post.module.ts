import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NewPostComponent } from './new-post/new-post.component';


@NgModule({
    declarations: [PostComponent, NewPostComponent],
    imports: [
        CommonModule, NgbModule
    ],
    exports: [PostComponent, NewPostComponent],
    bootstrap: [PostComponent, NewPostComponent]

})
export class PostModule { }
