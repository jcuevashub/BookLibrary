import { Component, ViewChild } from '@angular/core';
import { AppService } from '../services/app.service';
import { Book } from '../models/book';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { NotificationsService } from '../services/notifications.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home',
  styleUrls: ['home.component.css'],
  templateUrl: './home.component.html',
})


export class HomeComponent {
  
  displayedColumns: string[] = ['id', 'title', 'description', 'actions'];
  dataSource: MatTableDataSource<Book>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  //@ViewChild(MatSort) sort: MatSort;

  constructor(private appService: AppService, private notificationsService: NotificationsService) {}
  books: Book[] = [];

  ngOnInit() {
    this.dataSource = new MatTableDataSource(); // create new object
    this.loadBooks();// forgeted this line
    this.dataSource.paginator = this.paginator;
  }
 

  loadBooks() {
    this.appService.getBooks().subscribe((books: []) => {
      this.dataSource.data = books; 
      return books;
    }, error => {
      console.log('Hubo un error al cargar los books');
    }
    );
  }

  borrar(Id: number){
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this book!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.appService.deleteBookById(Id).subscribe(() => {
          Swal.fire(
            'Deleted!',
            'The book has been deleted.',
            'success'
          )
          this.appService.getBooks();
        }, (error) => {
          this.notificationsService.showError('Hubo un error al eliminar este libro!');
        });
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your book is safe :)',
          'error'
        )
      }
    });


  }

  details(Id: number) {

  }

  cancel() {

  }
}
