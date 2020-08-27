import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Book } from '../models/book';
import { Author } from '../models/author';
import { AppService } from '../services/app.service';
import { NotificationsService } from '../services/notifications.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  constructor(private appService: AppService, private notificationsService: NotificationsService, private router: Router, private route: ActivatedRoute) { }
  book: Book;
  author: Author;

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params['id'] !== '') {
        this.getBookById(+params['id']);
      }
    });
  }

  getBookById(Id: number) {
    this.appService.getBookById(Id).subscribe((result) => {
      this.book = result;
      this.getBookAuthorById(this.book.id);
    }, (error) => {
      this.notificationsService.showError('Hubo un error')
    });
  }

  getBookAuthorById(IdBook: number) { 
    this.appService.getBookAuthorById(IdBook).subscribe((result) => {
      this.author = result[0];
    }, (error) => {
      this.notificationsService.showError('Hubo un error')
    });

  }
}
