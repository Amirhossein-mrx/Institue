import { Component } from '@angular/core';
import { CourseService } from '../Service/course-services.service';
import { Observable } from 'rxjs';
import { instructoShow } from '../Models/Instructor-form-Model';

@Component({
  selector: 'app-show-instructor',
  templateUrl: './show-instructor.component.html',
  styleUrls: ['./show-instructor.component.css']
})
export class ShowInstructorComponent {

  constructor(private service: CourseService) { }

  instructors?: Observable<instructoShow[]>;

  ngOnInit(): void {

    this.instructors = this.service.showInstructor();
  }

  isDeleted = false;
  deleteInstructor(Id: number) {
    this.service.deleteInstructor({
      id: Id,
    }).subscribe(data => {
      console.log(data);
      if (data.message === 'Success') {
        this.isDeleted = true;
      }
    });
  }
}
