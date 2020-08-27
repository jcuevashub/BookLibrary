import { Injectable, Inject } from '@angular/core';
import { Book } from '../models/book';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Author } from '../models/author';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private apiBaseUrl) { }

  getBooks() {
    console.log('Holaaaa');
    return this.http.get<Book[]>(`${this.apiBaseUrl}api/books`);
  }

  getBookById(Id: number): Observable<Book>{
    return this.http.get<Book>(`${this.apiBaseUrl}api/books/${Id}`);
  }

  saveBook(book): Observable<Book> {
    return this.http.post<Book>(`${this.apiBaseUrl}api/books/`, book);
  }

  updateBook(book) {
    return this.http.put<Book>(`${this.apiBaseUrl}api/books/`, book);
  }

  deleteBookById(Id: number) {
    return this.http.delete<Book>(`${this.apiBaseUrl}api/books/${Id}`);
  }

  getBookAuthorById(IdBook: number): Observable<Author[]> {
    return this.http.get<Author[]>(`${this.apiBaseUrl}api/authors/books/${IdBook}`);
  }

}
