import { Component } from '@angular/core';
import { CourseService } from '../Service/course-services.service';

@Component({
  selector: 'app-instructor',
  templateUrl: './instructor.component.html',
  styleUrls: ['./instructor.component.css']
})
export class InstructorComponent {

  constructor(private service: CourseService) { }

  txtInstructorName: string;
  isAdded = false;

  SendInstructor() {
    this.service.sendNewiInstructor({
      instructorName: this.txtInstructorName,
    }).subscribe(data => {
      if (data.message === "Successful") {
        this.isAdded = true;
      }
    });

  }
}
