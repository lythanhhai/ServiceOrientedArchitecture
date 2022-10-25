import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/app-user';
import { Injectable } from '@angular/core';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  name = 'Ly Thanh Hai';
  users: User[] = [];

  constructor(
    private httpClient: HttpClient,
    private accountService: AccountService
  ) {}
  ngOnChanges(): void {
    this.accountService.showList();
    // this.accountService.users$.subscribe(res => this.users = res)
  }
  ngOnInit(): void {
    var token: string | null = '';
    var storageUser = localStorage.getItem('userToken');
    if (storageUser) {
      token = JSON.parse(storageUser).token;
    }
    // }
    var userToken = this.accountService.reLogin();
    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + `${this.accountService.valueInCurrentUser}`,
    });
    // this.httpClient.get<User[]>('https://localhost:7254/api/Auth', { headers: reqHeader }).subscribe(
    //   (response) => {
    //     // console.log(a)
    //     return (this.users = response);
    //   },
    //   (error) => {
    //     console.log(this.accountService.valueInCurrentUser);
    //     console.log(error);
    //   }
    // );
    this.accountService.showList();
  }
  ngDoCheck(): void {
    // this.accountService.showList();
    this.accountService.users$.subscribe((res) => (this.users = res));
  }
}
