import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BookService } from '../services/book.service';
import { Book } from '../models/book.model';
import { UpdateBookRequest } from '../models/update-book-request.model';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})
export class EditBookComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramsSubscription? : Subscription;
  editBookSubscription? : Subscription;
  book?: Book;

  constructor(private route: ActivatedRoute,
    private bookService: BookService,
    private router: Router
  ){

  }

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id){
          //get the data from the API 
          this.bookService.getBookById(this.id)
          .subscribe({
            next: (response) =>{
              this.book = response;
            }
          })
        }

      }
    })
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editBookSubscription?.unsubscribe();
  }

  onFormSubmit() : void{
    const UpdateBookRequest: UpdateBookRequest = {
      title : this.book?.title ?? '',
      author : this.book?.author ?? '',
      year : this.book?.year ?? 0,
      ISBN :  this.book?.isbn ?? ''
    };

    //Pass this object to service
    if(this.id){
       this.editBookSubscription = this.bookService.updateBook(this.id, UpdateBookRequest)
      .subscribe({
        next: (response) =>{
          this.router.navigateByUrl('admin/book')
        }
      });
    }
    
  }

  onDelete(): void{
    if(this.id)
    {
      this.bookService.deleteBook(this.id)
      .subscribe({
        next : (response) =>{
          this.router.navigateByUrl('admin/book');
        }
      })
    }
    
  }
}
