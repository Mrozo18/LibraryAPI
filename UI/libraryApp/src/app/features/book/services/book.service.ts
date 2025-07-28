import { Injectable } from '@angular/core';
import { AddBookRequest } from '../models/add-book-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book.model';
import { environment } from 'src/environments/environment';
import { UpdateBookRequest } from '../models/update-book-request.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  addBook(model : AddBookRequest) : Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Book`, model);
  }

  getAllBook() : Observable<Book[]>{
    return this.http.get<Book[]>(`${environment.apiBaseUrl}/api/Book`);
  }

  getBookById(id: string) : Observable<Book>{
    return this.http.get<Book>(`${environment.apiBaseUrl}/api/Book/${id}`);
  }

  updateBook(id: string, UpdateBookRequest: UpdateBookRequest): Observable<Book>{
    return this.http.put<Book>(`${environment.apiBaseUrl}/api/Book/${id}`, UpdateBookRequest);
  }

  deleteBook(id: string): Observable<Book>{
    return this.http.delete<Book>(`${environment.apiBaseUrl}/api/Book/${id}`);
  }
}
