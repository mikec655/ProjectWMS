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
        this.map = L.map('map')

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {}).addTo(this.map);

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(position => {
                this.map.setView([position.coords.latitude, position.coords.longitude], 11)
            });
        } else {
            this.map.setView([52.1092717, 5.1809676], 11);
        }

        this.updateMap();

    }

    showInvitation(post, invitation) {

        var coords = L.latLng(invitation.longitude, invitation.latitude, 0);

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
            .bindPopup(`<h6><a href='#'>${post.userFirstName} ${post.userLastName}</a></h6>${post.message}<br/><br/><span>0/${invitation.numberOfGuests} personen</span><button style='float: right'>Aanmelden</button>`, {
                minWidth: 180
            })
            .openPopup();
    }

    updateMap(): void {
        this.postService.getPosts(-1).subscribe(posts => {
            this.posts = posts
            this.posts.forEach(post => {
                this.postService.getInvitation(post.postId).subscribe(invitation => this.showInvitation(post, invitation))
            });
        });
    }

}
