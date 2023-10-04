import { Component } from '@angular/core';
import { CourseService } from '../Service/course-services.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent {

  constructor(private service: CourseService) { }

  txtCourseName = '';
  txtTeacherId: number;
  isAdded = false;


  SendCourse() {
    this.service.sendNewCourse({
      coursname: this.txtCourseName,
      instructorsid: this.txtTeacherId,
    }).subscribe(data => {
      if (data.message === 'Success') {
        this.isAdded = true;
      }
    });
  }
}
