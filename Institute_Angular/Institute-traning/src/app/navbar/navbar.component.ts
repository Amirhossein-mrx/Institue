import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  @Output() FeatureLoaded = new EventEmitter<string>();

  ClickCourse() {
    this.FeatureLoaded.emit('course');
  }
  ClickStudent() {
    this.FeatureLoaded.emit('student');
  }
  ClickInstructor() {
    this.FeatureLoaded.emit('instructor');
  }
}
