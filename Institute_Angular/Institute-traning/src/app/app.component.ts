import { Component, } from '@angular/core';
import { CourseService } from './Service/course-services.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor() { }




  pageloaded: string = "HomePage";
  onFeatureLoaded(page: string) {
    this.pageloaded = page;
  }





}
