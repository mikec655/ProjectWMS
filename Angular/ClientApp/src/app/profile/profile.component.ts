import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  //template url aanpassen naar een template die opgehaald wordt door authenticatie?

  //als deze variabele: notloggedin is dan veranderd htmllayout.
  //dus als we in de service checken of het id van de ingelodepersoon gelijkt is aand de pagina dan weergeven we dit?
  //geen idee of dit handig is tho, misschien beter om 2 componenten te maken.
  profileview = 'loggedin'
  constructor() { }

  ngOnInit() {
  }
  
}
