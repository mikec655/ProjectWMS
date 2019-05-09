import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-hello-world',
  templateUrl: './hello-world.component.html'
})
export class HelloWorldComponent {
  public text = "Hello World";s

  constructor(private titleService: Title) {
    this.titleService.setTitle("Hello World");
  }

  public print() {
    console.log(this.text);
  }
}
