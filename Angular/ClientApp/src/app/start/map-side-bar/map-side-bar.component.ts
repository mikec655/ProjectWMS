import { Component, OnInit } from '@angular/core';
declare let L;

@Component({
  selector: 'app-map-side-bar',
  templateUrl: './map-side-bar.component.html',
  styleUrls: ['./map-side-bar.component.css']
})

export class MapSideBarComponent implements OnInit {
  private km: any=1;

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

    //L.greatCircle(52.1092717, 5.1809676, { fill: 'red' }).addTo(map);

    var app = L.module("demoapp", ["leaflet-directive"]);
    app.controller("BasicGeoJSONUpdateController", ['$scope', '$http', 'leafletData', function ($scope, $http, leafletData) {
      L.extend($scope, {
        center: {
          lat: 31.99,
          lng: -33.43,
          zoom: 3
        },
        geojson: {
          data: {
            "type": "FeatureCollection",
            "features": [
              {
                "type": "Feature",
                "properties": {},
                "geometry": {
                  "type": "Polygon",
                  "coordinates": [
                    [
                      [
                        -49.92187499999999,
                        13.239945499286312
                      ],
                      [
                        -49.92187499999999,
                        54.57206165565852
                      ],
                      [
                        -13.7109375,
                        54.57206165565852
                      ],
                      [
                        -13.7109375,
                        13.239945499286312
                      ],
                      [
                        -49.92187499999999,
                        13.239945499286312
                      ]
                    ]
                  ]
                }
              }
            ]
          },
          style: {
            fillColor: "green",
            weight: 2,
            opacity: 1,
            color: 'white',
            dashArray: '3',
            fillOpacity: 0.7
          }
        }
      });

      $scope.updateGeojson = function () {
        $scope.geojson.data = {
          "type": "FeatureCollection",
          "features": [
            {
              "type": "Feature",
              "properties": {},
              "geometry": {
                "type": "Polygon",
                "coordinates": [
                  [
                    [
                      -41.8359375,
                      28.92163128242129
                    ],
                    [
                      -41.8359375,
                      38.272688535980976
                    ],
                    [
                      -26.015625,
                      38.272688535980976
                    ],
                    [
                      -26.015625,
                      28.92163128242129
                    ],
                    [
                      -41.8359375,
                      28.92163128242129
                    ]
                  ]
                ]
              }
            }
          ]
        };
      }
    }]);
  }
}
