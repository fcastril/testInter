import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserResponseModel } from '../models/userResponse.model';
import { map } from 'rxjs/operators';
import { CommonService } from './common.service';
import { ResponseModel } from '../models/response.model';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userToken: string;

  constructor(private http: HttpClient, private common: CommonService) {
    this.getToken();
  }
  
  login( user: UserResponseModel ) {
    const authData = {
      ...user,
      returnSecureToken: true
    };


    return this.http.post(
      `${ this.common.getUrl() }/Token`,
      authData);
    // ).pipe(
    //   map( (resp: ResponseModel) => {
    //     console.log('AUTH',resp);
    //     this.setToken( resp.result['token'] );
    //     return resp;
    //   })
    // );

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
  
  setToken( idToken: string ) {

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

  
  newUser( user: UserModel ) {

    const userData = {
      ...user,
      id: 0
    };
    
    return this.http.post(
      `${ this.common.getUrl() }/user`,
      userData
    );

  }

  getHeaders(){
    return new HttpHeaders({Authorization: `Bearer ${this.getToken()}`});

  }

}
