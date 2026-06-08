import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private apiUrl = 'https://jsonplaceholder.typicode.com/posts';

  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    return this.http.get<any[]>(this.apiUrl).pipe(
      map(posts =>
        posts.slice(0, 10).map(post => ({
          id: post.id,
          title: post.title,
          price: 500 + post.id * 100,
          publicationDate: '2024-01-01',
          description: post.body
        }))
      )
    );
  }
}