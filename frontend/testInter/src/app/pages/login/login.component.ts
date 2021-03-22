import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { UserModel } from '../../models/user.model';
import { AuthService } from '../../services/auth.service';
import { UserResponseModel } from 'src/app/models/userResponse.model';
import Swal from 'sweetalert2';
import { ResponseModel } from 'src/app/models/response.model';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: UserResponseModel = new UserResponseModel();
  remember:boolean = false;

  constructor( private auth: AuthService,
               private router: Router ) { }

  ngOnInit() {


    this.user.email = 'admon@correo.com';
    this.user.password = '1234';
    if ( localStorage.getItem('email') ) {
      this.user.email = localStorage.getItem('email');
      this.remember = true;
    }

  }


  login( form: NgForm ) {

    if (  form.invalid ) { return; }


    Swal.fire({
      allowOutsideClick: false,
      icon: 'info',
      text: 'Espere por favor...'
    });
    Swal.showLoading();

    this.auth.login( this.user )
      .subscribe( (resp: ResponseModel) => {
        Swal.close();
        if (resp.response)
        {
          this.auth.setToken( resp.result['token'] )
        if ( this.remember ) {
          localStorage.setItem('email', this.user.email);
        }


        this.router.navigateByUrl('/home');
      }
      else
      {
        Swal.fire({
         icon: 'error',
          title: 'Error al autenticar',
         text: 'El Email o la contraseña son incorrectas'
        });
      }


      }, (err) => {

        console.log(err.error.error.message);

      });

  }

}