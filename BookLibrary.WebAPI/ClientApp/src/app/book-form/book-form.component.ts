import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NotificationsService } from '../services/notifications.service';
import { AppService } from '../services/app.service';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { Book } from '../models/book';

@Component({
  selector: 'app-book-form',
  styleUrls: ['./book-form.component.css'],
  templateUrl: './book-form.component.html',
})
export class BookFormComponent implements OnInit {
  bookForm: FormGroup;
  book: Book;
  id: number;
  private sub: any;
  isEditing =  false;
  constructor(private appService: AppService, private notificationsService: NotificationsService, private router: Router, private route: ActivatedRoute){}


  ngOnInit() {
  this.buildForm();
    this.route.params.subscribe(params => {
      if (params['id'] !== '') {
        this.isEditing = true;
        this.getBookById(+params['id']);
        
      }
    });
  }

  getBookById(Id: number) {
    this.appService.getBookById(Id).subscribe((result) => {
      console.log(result);
      this.bookForm.patchValue({
        id: result.id,
        title: result.title,
        description: result.description,
        pageCount: result.pageCount,
        excerpt: result.excerpt
      });
    }, (error) => {
      this.notificationsService.showError('Hubo un error')
    });
  }


  private buildForm() {
    this.bookForm = new FormGroup({
      id: new FormControl(''),
      title: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      pageCount: new FormControl('', Validators.required),
      excerpt: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    const bookInfo = this.bookForm.getRawValue();

    const request = {
      title: bookInfo.title,
      description: bookInfo.description,
      pageCount: bookInfo.pageCount,
      excerpt: bookInfo.excerpt
    };

    this.appService.saveBook(request).subscribe((result) => {
      this.notificationsService.showSucces('El libro se ha creado con exito!');
      this.bookForm.reset();
    }, (error) => {
      this.notificationsService.showError('Hubo un error al guadar el libro');
    });
  }

  updateBook() {
    const bookInfo = this.bookForm.getRawValue();

    const request = {
      id: bookInfo.id,
      title: bookInfo.title,
      description: bookInfo.description,
      pageCount: bookInfo.pageCount,
      excerpt: bookInfo.excerpt
    };
    console.log(request);
    this.appService.updateBook(request).subscribe((result) => {
      this.notificationsService.showSucces('El libro se ha actualizado con exito!');
      this.bookForm.reset();
      this.router.navigate(['']);
    }, (error) => {
      this.notificationsService.showError('Hubo un error al actualizar el libro');
    });
  }

  cancel() {
    this.bookForm.reset();
  }
}
