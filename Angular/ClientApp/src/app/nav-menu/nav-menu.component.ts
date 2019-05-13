import { Component } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  animations: [
    trigger('collapse', [
      state('open', style({
        opacity: '1',
        display: 'block',
        transform: 'translate3d(0, 0, 0)'
      })),
      state('closed', style({
        opacity: '0',
        display: 'none',
        transform: 'translate3d(0, -100%, 0)'
      })),
      transition('closed => open', animate('400ms 100ms ease-in-out')),
      transition('open => closed', animate('400ms 100ms ease-in-out'))
    ])
  ]
})
export class NavMenuComponent {
  isExpanded = true;
  maxHeight = 70;

  close() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  collapse: string = "closed";

  toggleCollapse() {
    // this.show = !this.show
    this.collapse = this.collapse == "open" ? 'closed' : 'open';
    this.isExpanded = this.collapse == "open" ? true : false;
    this.maxHeight = this.isExpanded ? 500 : 65;
    delay(600).then(() => { this.maxHeight = 200; console.log("fired")});
  }
}
