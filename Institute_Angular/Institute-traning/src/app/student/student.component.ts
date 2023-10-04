import { Component } from '@angular/core';
import { CourseService } from '../Service/course-services.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {
  constructor(private service: CourseService) { }
  txtStudentName: string;
  txtStudentFamily: string;
  isAdded = false;

  SendStudent() {
    this.service.sendNewStudent({
      name: this.txtStudentName,
      family: this.txtStudentFamily,
    }).subscribe(data => {
      if (data.message === 'Successful') {
        this.isAdded = true;
      };
    })
  }
}
