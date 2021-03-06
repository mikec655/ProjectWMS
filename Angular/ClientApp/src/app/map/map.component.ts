import { Component, OnInit } from '@angular/core';
import { PostService } from '../post/post.service';
import { environment } from '../../environments/environment';
declare let L;

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],

})
export class MapComponent implements OnInit {

  private map
  private posts = []

  constructor(private postService: PostService) { }

  ngOnInit() {
    this.map = L.map('map')

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {}).addTo(this.map);

    this.map.setView([52.1092717, 5.1809676], 7);

    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(position => {
        this.map.setView([position.coords.latitude, position.coords.longitude], 11)
      });
    } else {
      this.map.setView([52.1092717, 5.1809676], 7);
    }

    this.updateMap();

  }

  showInvitation(post, invitation) {
    console.log(invitation)

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

    var container = L.DomUtil.create('div');
    var btn = L.DomUtil.create('button', '', container);
    btn.setAttribute('type', 'button');
    btn.setAttribute('class', 'btn btn-primary btn-sm accept-button')
    btn.setAttribute('style', 'width: 100%');
    btn.setAttribute('data-id', post.postId)
    btn.innerHTML = "Accept";
    container.innerHTML = '' + btn.outerHTML;

    let popUp = L.popup()
      .setLatLng(coords)
      .setContent("<script></script><h6><a href='#'>" + post.userFirstName + " " + post.userLastName +
        "</a></h6><span class='badge badge-info'>" + invitation.type + "</span> - <span class='badge badge-light'>0 / " +
        invitation.numberOfGuests + " guests</span><br/><br/>" + this.Unix_timestamp(invitation.invitationDateUnix) + "<br/>" +
        invitation.address + "<br/><br/>" + post.message + "<br/><br/>" + container.innerHTML)


    L.marker(coords, { icon: customIcon }).addTo(this.map)
      .bindPopup(popUp, {
        minWidth: 180,
        maxWidth: 360
      })

    let self = this

    this.map.on('popupopen', function () {
      $('.accept-button').click(function (e) {
        console.log(this.getAttribute("data-id"));
        self.postService.acceptInvitation(1)
      });
    });

  }

  updateMap(): void {
    this.postService.getPosts(-1).subscribe(posts => {
      this.posts = posts
      this.posts.forEach(post => {
        if (post.invitationId) {
          this.postService.getInvitation(post.postId).subscribe(invitation => this.showInvitation(post, invitation));
        }
      });
    });
  }

  acceptInvitation(postId) {

    $.post(`${environment.apiUrl}/api/Posts/${postId}/Invitation/Accept`, {})

  }

  Unix_timestamp(t) {
    const monthNames = ["januari", "februari", "maart", "april", "mei", "juni",
      "juli", "augustus", "september", "oktober", "november", "december"
    ];
    var dt = new Date(t);
    var y = dt.getFullYear();
    var mth = dt.getMonth();
    var d = "0" + dt.getDate();
    var hr = "0" + dt.getHours();
    var m = "0" + dt.getMinutes();

    return d.substr(-2) + ' ' + monthNames[mth] + ' ' + y + ' ' +
      hr.substr(-2) + ':' + m.substr(-2);
  }
}
