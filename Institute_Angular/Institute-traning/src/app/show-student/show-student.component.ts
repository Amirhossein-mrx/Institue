import { Component } from '@angular/core';
import { CourseService } from '../Service/course-services.service';
import { StudentShow } from '../Models/Student-form-Model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-show-student',
  templateUrl: './show-student.component.html',
  styleUrls: ['./show-student.component.css']
})
export class ShowStudentComponent {
  constructor(private service: CourseService) { }

  students?: Observable<StudentShow[]>;

  ngOnInit() {
    this.students = this.service.showStudent();
  }
}
