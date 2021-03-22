import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserResponseModel } from '../models/userResponse.model';
import { environment } from '../../environments/environment.prod';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userToken: string;

  constructor(private http: HttpClient, private environment) {
    this.getToken();
  }
  
  login( user: UserResponseModel ) {

    const authData = {
      ...user,
      returnSecureToken: true
    };

    return this.http.post(
      `${ this.environment.url }/Token`,
      authData
    ).pipe(
      map( resp => {
        this.setToken( resp['idToken'] );
        return resp;
      })
    );

  }
  logout() {
    localStorage.removeItem('token');
  }
  getToken() {

    if ( localStorage.getItem('token') ) {
      this.userToken = localStorage.getItem('token');
    } else {
      this.userToken = '';
    }

    return this.userToken;

  }
  
  private setToken( idToken: string ) {

    this.userToken = idToken;
    localStorage.setItem('token', idToken);

    let hoy = new Date();
    hoy.setSeconds( 3600 );

    localStorage.setItem('expire', hoy.getTime().toString() );


  }
  
  isAuth(): boolean {

    if ( this.userToken.length < 2 ) {
      return false;
    }

    const expire = Number(localStorage.getItem('expire'));
    const expireDate = new Date();
    expireDate.setTime(expire);

    if ( expireDate > new Date() ) {
      return true;
    } else {
      return false;
    }


  }
}
