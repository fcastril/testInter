import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { UserModel } from '../../models/user.model';
import { AuthService } from '../../services/auth.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  user: UserModel=new UserModel();
  remenber = false;

  constructor( private auth: AuthService,
               private router: Router ) { }

  ngOnInit() {
    this.user = new UserModel();
  }

  onSubmit( form: NgForm ) {

    if ( form.invalid ) { return; }

    Swal.fire({
      allowOutsideClick: false,
      icon: 'info',
      text: 'Espere por favor...'
    });
    Swal.showLoading();
    console.log(this.user);

    this.auth.newUser( this.user )
      .subscribe( resp => {

        console.log(resp);
        Swal.close();

        if ( this.remenber ) {
          localStorage.setItem('email', this.user.email);
        }

        this.router.navigateByUrl('/home');

      }, (err) => {
        console.log(err.error.error.message);
        Swal.fire({
          icon: 'error',
          title: 'Error al autenticar',
          text: err.error.error.message
        });
      });
  }


}
