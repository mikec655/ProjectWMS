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
        height: 'auto',
        transform: 'translate3d(0, 0, 0)'
      })),
      state('closed', style({
        opacity: '0',
        display: 'block',
        height: '0',
        transform: 'translate3d(0, -200%, 0)'
      })),
      transition('closed => open', animate('400ms ease-in')),
      transition('open => closed', animate('400ms ease-out'))
    ])
  ]
})
export class NavMenuComponent {
  isExpanded = true;

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
  }
}
