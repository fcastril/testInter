import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  private url = 'https://localhost:44307/api';
  // private url = 'https://backendphvirtual.azurewebsites.net/api/';

  constructor() { }

  getUrl(): string {
    return this.url;
  }
}
