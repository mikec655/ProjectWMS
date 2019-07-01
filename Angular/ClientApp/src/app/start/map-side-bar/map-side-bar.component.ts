import { Component, OnInit } from '@angular/core';
declare let L;

@Component({
    selector: 'app-map-side-bar',
    templateUrl: './map-side-bar.component.html',
    styleUrls: ['./map-side-bar.component.css']
})

export class MapSideBarComponent implements OnInit {
    private km: any = 1;

    constructor() { }
    ngOnInit() {

        navigator.geolocation.getCurrentPosition(this.showPosition);



    }


    onChange(event) {
        this.km = event.target.value;
    }


    showPosition(position) {

        var map = L.map('map').setView([52.1092717, 5.1809676], 11);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {}).addTo(map);

        L.marker([52.1092717, 5.1809676]).addTo(map)
            .bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
            .openPopup();
    }
}
