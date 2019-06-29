import { Component, OnInit } from '@angular/core';
import { PostService } from '../post/post.service';
declare let L;

@Component({
    selector: 'app-map',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {

    private map
    private posts = []

    constructor(private postService: PostService) { }

    ngOnInit() {

        this.map = L.map('map').setView([52.1092717, 5.1809676], 11);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {}).addTo(this.map);

        this.updateMap();

    }

    showInvitation(invitation) {
        console.log(invitation);

        var coords = L.latLng(invitation.latitude, invitation.longitude, 0);

        var customIcon = L.icon({
            iconUrl: 'assets/leaflet/images/marker-icon-2x.png',
            shadowUrl: 'assets/leaflet/images/marker-shadow.png',
            iconSize: [24, 40],
            shadowSize: [24, 40],
            iconAnchor: [12, 40],
            shadowAnchor: [4, 62],
            popupAnchor: [0, -38]
        });

        L.marker(coords, { icon: customIcon }).addTo(this.map)
            .bindPopup("<h5>{Title}</h5><h6>{User}</h6>{post abcdefghijklmnopqrstuvwqxyz}<br/><br/><span>0/4 personen</span><button style='float: right'>Aanmelden</button>")
            .openPopup();
    }

    updateMap(): void {
        this.postService.getPosts(-1).subscribe(posts => {
            console.log(posts)
            this.posts = posts
            this.posts.forEach(post => {
                console.log("XXX")
                this.postService.getInvitation(post.postId).subscribe(invitation => this.showInvitation(invitation))
            });
        });
    }

}
