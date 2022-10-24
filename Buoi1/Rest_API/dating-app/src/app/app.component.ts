import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/app-user';
import { Injectable } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  name = 'Ly Thanh Hai';
  users: User[] = [];

  constructor(private httpClient: HttpClient) {}

  ngOnInit(): void {
    // var header = {
    //   headers: new HttpHeaders().set(
    //     'Authorization',
    //     `Basic eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJseXRoYW5oaGFpIiwiZW1haWwiOiJseXRoYW5oaGFpQGRhdGluZy5hcHAiLCJuYmYiOjE2NjY1ODUwMDQsImV4cCI6MTY2NjY3MTQwNCwiaWF0IjoxNjY2NTg1MDA0fQ.Lpm7WIzdUf79w3SRhcgYNHRK6Sn8bTlibr4bz7p4pBVhcLNwtqhPq-mUWpagvMeMqRVKAjRYpxFZviVvEuD7Uw`
    //   ),
    // };
    
    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization:
        'Bearer ' +
        `eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJseXRoYW5oaGFpIiwiZW1haWwiOiJseXRoYW5oaGFpQGRhdGluZy5hcHAiLCJuYmYiOjE2NjY1ODUwMDQsImV4cCI6MTY2NjY3MTQwNCwiaWF0IjoxNjY2NTg1MDA0fQ.Lpm7WIzdUf79w3SRhcgYNHRK6Sn8bTlibr4bz7p4pBVhcLNwtqhPq-mUWpagvMeMqRVKAjRYpxFZviVvEuD7Uw`,
    });
    this.httpClient
      .get<User[]>('https://localhost:7254/api/Auth', { headers: reqHeader })
      .subscribe(
        (response) => {
          // console.log(response.headers.get('Authorization'));
          return (this.users = response);
        },
        (error) => console.log(error)
      );
  }
}
