import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { UsersComponent } from './pages/users/users.component';
import { EmployeesComponent } from './pages/employees/employees.component';
import { EmployeeCrudComponent } from './pages/employees/employee-crud.component';

const routes: Routes = [
  { path: 'home'    , component: HomeComponent, canActivate: [ AuthGuard ] },
  { path: 'users'    , component: UsersComponent, canActivate: [ AuthGuard ] },
  { path: 'employees'    , component: EmployeesComponent, canActivate: [ AuthGuard ] },
  { path: 'employee-crud/:id'    , component: EmployeeCrudComponent, canActivate: [ AuthGuard ] },
  { path: 'login'   , component: LoginComponent },
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
