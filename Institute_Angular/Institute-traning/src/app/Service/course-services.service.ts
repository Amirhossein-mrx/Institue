import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CourseInterShows, CourseInterface, CourseInterfaceResult } from '../Models/Course-form-Model';
import { Observable } from 'rxjs';
import { StudentInterface, StudentInterfaceResult, StudentShow } from '../Models/Student-form-Model';
import { instructoInterface, instructoInterfaceResult, instructoShow } from '../Models/Instructor-form-Model';
@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient) { }

  private api: string = "http://localhost:19785/api/Cours/addnew";
  private api2: string = "http://localhost:19785/api/Cours/getAll";
  private apiStudentShow: string = "http://localhost:19785/api/Student/getAll";
  private apiStudentAdd: string = "http://localhost:19785/api/Student/addnew";
  private apiinstructorShow: string = "http://localhost:19785/api/Instructors/getAll";
  private apiinstructorAdd: string = "http://localhost:19785/api/Instructors/addnew";

  sendNewCourse(course: CourseInterface): Observable<CourseInterfaceResult> {
    return this.http.post(this.api, course) as Observable<CourseInterfaceResult>;
  }
  s
  showCourses(): Observable<CourseInterShows[]> {
    return this.http.get(this.api2) as Observable<CourseInterShows[]>;
  }

  showStudent(): Observable<StudentShow[]> {
    return this.http.get(this.apiStudentShow) as Observable<StudentShow[]>;
  }

  sendNewStudent(student: StudentInterface): Observable<StudentInterfaceResult> {
    return this.http.post(this.apiStudentAdd, student) as Observable<StudentInterfaceResult>;
  }

  showInstructor(): Observable<instructoShow[]> {
    return this.http.get(this.apiinstructorShow) as Observable<instructoShow[]>;
  }

  sendNewiInstructor(instructor: instructoInterface): Observable<instructoInterfaceResult> {
    return this.http.post(this.apiinstructorAdd, instructor) as Observable<instructoInterfaceResult>;
  }

}
