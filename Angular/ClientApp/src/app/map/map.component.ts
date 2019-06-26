import { Component, OnInit } from '@angular/core';
declare let L;



@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

    private map 
    private locations = [
        [ 52.1092717, 5.1809676 ],
        [ 52.1271700, 5.1809676 ],
        [ 52.1092717, 5.1009676 ]


    ]

  constructor() { }

  ngOnInit() {

      this.map = L.map('map').setView([52.1092717, 5.1809676], 11);

      L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {}).addTo(this.map);

      this.updateMap();
    
  }

    showPosition(location) {

        var customIcon = L.icon({
            iconUrl: 'assets/leaflet/images/marker-icon-2x.png',
            shadowUrl: 'assets/leaflet/images/marker-shadow.png',
            iconSize: [24, 40],
            shadowSize: [24, 40],
            iconAnchor: [12, 40],
            shadowAnchor: [4, 62],
            popupAnchor: [0, -38]
        });

       L.marker(location, { icon: customIcon }).addTo(this.map)
           .bindPopup("<h5>{Title}</h5><h6>{User}</h6>{post abcdefghijklmnopqrstuvwqxyz}<br/><br/><span>0/4 personen</span><button style='float: right'>Aanmelden</button>")
      .openPopup();
    }

    updateMap(): void {
        this.locations.forEach(location => this.showPosition(location));
    }

}
