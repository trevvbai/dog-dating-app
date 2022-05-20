import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dog } from './models/dog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Doggio';
  dogs: Dog[];

  constructor(private httpClient: HttpClient) {}

  ngOnInit() {
    this.getUsers();
  }

  private getUsers(): void {
    this.httpClient.get('https://localhost:5001/api/dogs').subscribe({
      next: (res: Dog[]) => (this.dogs = res),
      error: (err) => console.log(err),
    });
  }
}
