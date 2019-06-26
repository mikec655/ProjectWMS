import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [PostComponent],
  imports: [
    CommonModule, NgbModule
  ],
  exports: [PostComponent],
  bootstrap: [PostComponent]

})
export class PostModule { }
