import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseListComponent } from './course-list/course-list';
import { CourseDetailComponent } from './course-detail/course-detail';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    CourseListComponent,
    CourseDetailComponent
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  courses = [
    {
      id: 1,
      title: 'Angular Fundamentals',
      description: 'Learn Angular basics and components'
    },
    {
      id: 2,
      title: 'TypeScript Essentials',
      description: 'Master TypeScript concepts'
    },
    {
      id: 3,
      title: 'Web Development',
      description: 'Build modern web applications'
    }
  ];

  selectedCourse = this.courses[0];

  selectCourse(course: any) {
    this.selectedCourse = course;
  }
}