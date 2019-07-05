import { Component, OnInit } from '@angular/core';
declare let L;

@Component({
    selector: 'app-map-side-bar',
    templateUrl: './map-side-bar.component.html',
    styleUrls: ['./map-side-bar.component.css']
})

export class MapSideBarComponent implements OnInit {
    private km: any = 1;
    private map;

    constructor() { }
    ngOnInit() {

        const map = L.map('map').setView([51.505, -0.09], 13);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);



    }


    // onChange(event) {
    //     // this.km = event.target.value;
    // }


    // showPosition(position) {


    // }
}
