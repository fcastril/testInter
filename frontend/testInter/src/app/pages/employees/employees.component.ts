import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { EmployeeModel } from '../../models/employee.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  private regs:EmployeeModel[];
  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api.get('Employee').subscribe(
      (resp: EmployeeModel[]) => this.regs = resp
    );
  }
  delete(id, idx){
    console.log(id);
    Swal.fire({
      title: 'Desea Eliminar El Registro?',
      showCancelButton: true,
      confirmButtonText: 'SI',
      cancelButtonText: 'NO'
    }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.value) {
        this.api.delete("Employee",id).subscribe(
          (resp: any)=>{
            console.log('resp', resp);
          if (resp.error) {
              Swal.fire('Error al crear el Registro','Se presentó un error al crear el registro', 'error');
          } else {
            this.regs.splice(idx);
          }
        });
      } 
    })
  }

}
