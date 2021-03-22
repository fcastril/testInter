import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { CommonService } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor( private auth: AuthService,
    private http: HttpClient,
    private common: CommonService) { }

  get( controller: string ) {
    return this.http.get(`${ this.common.getUrl() }/${ controller }`, { headers: this.auth.getHeaders() });
  }
  getId( controller: string, id: string ) {
    return this.http.get(`${ this.common.getUrl() }/${ controller }/${id}`, { headers: this.auth.getHeaders() });
  }
  delete( controller: string, id: number) {
    return this.http.delete(`${ this.common.getUrl() }/${ controller }/${id}`, { headers: this.auth.getHeaders() });
  }
  post( controller: string, data: any) {
    console.log(`${ this.common.getUrl() }/${ controller }`);
    return this.http.post(`${ this.common.getUrl() }/${ controller }`, data, { headers: this.auth.getHeaders() } );
  }
  put( controller: string, data: any, id: number) {
    return this.http.put(`${ this.common.getUrl() }/${ controller }/${id}`, data, { headers: this.auth.getHeaders() } );
  }
}
