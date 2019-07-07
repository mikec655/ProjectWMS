import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NewPostComponent } from './new-post/new-post.component';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';


@NgModule({
  declarations: [PostComponent, NewPostComponent],
  imports: [
    CommonModule,
    NgbModule,
    MatCardModule,
    MatExpansionModule,
    MatSnackBarModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatSlideToggleModule
  ],
  exports: [PostComponent, NewPostComponent],
  bootstrap: [PostComponent, NewPostComponent]

})
export class PostModule { }
