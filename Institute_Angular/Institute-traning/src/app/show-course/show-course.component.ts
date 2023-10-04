import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseInterShows } from '../Models/Course-form-Model';
import { CourseService } from '../Service/course-services.service';

@Component({
  selector: 'app-show-course',
  templateUrl: './show-course.component.html',
  styleUrls: ['./show-course.component.css']
})
export class ShowCourseComponent {
  constructor(private service: CourseService) { }

  courses?: Observable<CourseInterShows[]>;
  ngOnInit(): void {
    this.courses = this.service.showCourses();
  }
}
