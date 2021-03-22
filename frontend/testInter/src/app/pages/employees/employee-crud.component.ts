import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeModel } from '../../models/employee.model';
import { ApiService } from '../../services/api.service';
import Swal from 'sweetalert2';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-employee-crud',
  templateUrl: './employee-crud.component.html',
  styleUrls: ['./employee-crud.component.css']
})
export class EmployeeCrudComponent implements OnInit {

  private reg: EmployeeModel = new  EmployeeModel();
  id: string;
  isNew:boolean;
  navigateToPage='/employees';
  constructor(private route: ActivatedRoute, private api: ApiService, private router: Router) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id === '0') {
      this.isNew = true;
      this.reg = new EmployeeModel();
    } else {
      this.isNew = false;
      this.api.getId('Employee',this.id).subscribe(
        (resp: EmployeeModel) => this.reg = resp
      );
  }
}
  save(form:NgForm){
    if (form.invalid) {
      Object.values(form.controls).forEach( ctrl => {
        ctrl.markAsTouched();
      });
 
      Swal.fire(
        {
          title: 'Error',
          text: 'Hacen falta campos obligatorios',
          icon: 'error'
        }
      );
      return;
    }
 
    Swal.fire(
      {
        title: 'Confirmar Guardar !!!',
        text: '¿Está seguro de guardar el registro actual?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Guardar'
      }
    ).then((result)=> {
      if (result.value) {
        console.log(this.reg.id);
        if (this.reg.id === 0){
          this.api.post("Employee",this.reg).subscribe(
            (resp: any)=>{
              console.log('resp', resp);
            if (resp.error) {
                Swal.fire('Error al crear el Registro','Se presentó un error al crear el registro', 'error');
            } else {
              this.router.navigateByUrl(this.navigateToPage);
            }
          });
        } else {
          this.api.put("employee",this.reg, this.reg.id).subscribe(
            (resp: any)=>{
            if (resp.error) {
                Swal.fire('Error al actualizar el Registro','Se presentó un error al actualizar el registro', 'error');
            } else {
              this.router.navigateByUrl(this.navigateToPage);
            }
          });
        }
      }
    });
  }
}
