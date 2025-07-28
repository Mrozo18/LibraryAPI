import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './features/book/book-list/book-list.component';
import { AddCategoryComponent } from './features/book/add-category/add-category.component';
import { EditBookComponent } from './features/book/edit-book/edit-book.component';

const routes: Routes = [
  {
    path: 'admin/book',
    component : BookListComponent
  },
  {
    path: 'admin/book/add',
    component : AddCategoryComponent
  },
  {
    path: 'admin/book/:id',
    component: EditBookComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
