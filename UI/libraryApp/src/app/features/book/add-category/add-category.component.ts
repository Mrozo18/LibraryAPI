import { Component, OnDestroy } from '@angular/core';
import { AddBookRequest } from '../models/add-book-request.model';
import { BookService } from '../services/book.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy
{

  model: AddBookRequest;
  private addBookSubscription?:  Subscription;

  constructor(private bookService: BookService, private router: Router)
  {
    this.model = {
      title: '',
      author: '',
      year: 0,
      ISBN: ''
    }
  }

  onFormSubmit()
  {
    this.addBookSubscription = this.bookService.addBook(this.model)
    .subscribe({
      next: (response) => {
        this.router.navigateByUrl('/admin/book');
      },
      error: (error) => {

      }
    })
  }

  ngOnDestroy(): void {
    this.addBookSubscription?.unsubscribe();
  }

}
