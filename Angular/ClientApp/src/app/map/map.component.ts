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

    showPosition(position: Position) {
        console.log(position);
        var coords = L.latLng(position.coords.latitude, position.coords.longitude, position.coords.altitude);
        var map = L.map('map').setView(coords, 11);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {}).addTo(map);

        L.marker(coords).addTo(map)
            .bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
            .openPopup();
    }

}
