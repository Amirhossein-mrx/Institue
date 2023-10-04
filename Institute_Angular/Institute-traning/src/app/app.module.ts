import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ShowCourseComponent } from './show-course/show-course.component';
import { NavbarComponent } from './navbar/navbar.component';
import { StudentComponent } from './student/student.component';
import { CourseComponent } from './course/course.component';
import { ShowStudentComponent } from './show-student/show-student.component';
import { ShowInstructorComponent } from './show-instructor/show-instructor.component';
import { InstructorComponent } from './instructor/instructor.component';
@NgModule({
  declarations: [
    AppComponent,
    ShowCourseComponent,
    NavbarComponent,
    StudentComponent,
    CourseComponent,
    ShowStudentComponent,
    ShowInstructorComponent,
    InstructorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
