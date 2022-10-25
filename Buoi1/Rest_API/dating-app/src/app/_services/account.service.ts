import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, pipe, ReplaySubject } from 'rxjs';
import { AuthUser, User, UserToken } from 'src/models/app-user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl: string = 'https://localhost:7254/api/Auth/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  private currentUser = new BehaviorSubject<UserToken | null>(null);
  currentUser$ = this.currentUser.asObservable();
  private users: ReplaySubject<User[]> = new ReplaySubject();
  users$ = this.users.asObservable();

  constructor(private httpClient: HttpClient) {}

  get valueInCurrentUser() {
    return this.currentUser.getValue()?.token;
  }

  // get getListUser() {
  //   return this.users$.subscribe(val => {
   
  //   });
  // }
  login(authUser: AuthUser): Observable<any> {
    return this.httpClient
      .post<any>(`${this.baseUrl}login`, authUser, this.httpOptions)
      .pipe(
        map((response: UserToken) => {
          if (response) {
            this.currentUser.next(response);
            localStorage.setItem('userToken', JSON.stringify(response));
          }
        })
      );
  }
  logout() {
    this.currentUser.next(null);
    localStorage.removeItem('userToken');
  }

  reLogin() {
    const storageUser = localStorage.getItem('userToken');
    if (storageUser) {
      const userToken = JSON.parse(storageUser);
      this.currentUser.next(userToken);
      return userToken.token;
      // return userToken
    }
  }
  showList() {
    var reqHeader = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + `${this.currentUser.getValue()?.token}`,
    });
    this.httpClient
      .get<User[]>('https://localhost:7254/api/Auth', { headers: reqHeader })
      .subscribe(
        (response) => {
          this.users.next(response);
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
