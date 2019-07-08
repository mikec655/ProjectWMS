import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NewPostComponent, NewPostDialog } from './new-post/new-post.component';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [PostComponent, NewPostComponent, NewPostDialog],
  imports: [
    CommonModule,
    NgbModule,
    MatCardModule,
    MatExpansionModule,
    MatSnackBarModule,
    MatButtonModule,
    MatDialogModule,
    MatInputModule,
    MatSlideToggleModule,
    FormsModule
  ],
  exports: [PostComponent, NewPostComponent, NewPostDialog],
  bootstrap: [PostComponent, NewPostComponent, NewPostDialog]

})
export class PostModule { }
