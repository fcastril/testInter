import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { UserModel } from '../../models/user.model';
import { AuthService } from '../../services/auth.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: UserModel = new UserModel();
  remember:boolean = false;

  constructor( private auth: AuthService,
               private router: Router ) { }

  ngOnInit() {

    if ( localStorage.getItem('email') ) {
      this.user.email = localStorage.getItem('email');
      this.remember = true;
    }

  }


  login( form: NgForm ) {

    if (  form.invalid ) { return; }

    this.auth.login( this.user )
      .subscribe( resp => {
        if ( this.remember ) {
          localStorage.setItem('email', this.user.email);
        }


        this.router.navigateByUrl('/home');

      }, (err) => {

        console.log(err.error.error.message);

      });

  }

}