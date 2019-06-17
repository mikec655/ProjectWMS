import { Component, OnInit } from '@angular/core';
declare let L;

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

  constructor() { }

  ngOnInit() {

    navigator.geolocation.getCurrentPosition(this.showPosition);
    
  }

  showPosition(position) {

    var map = L.map('map').setView([52.1092717, 5.1809676], 11);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {}).addTo(map);

    L.marker([52.1092717, 5.1809676]).addTo(map)
      .bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
      .openPopup();
  }

}
