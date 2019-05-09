import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public blogs: Blog[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Blog[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.blogs = result;
    }, error => console.error(error));
  }
}

interface Blog {
  blogId: number;
  url: string;
  posts: any;
}

interface Post {
  PostId: number;
  Title: string;
  Content: string;
  BlogId: number;
}
