import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

constructor() { }

  public loadingMessage(message: string) {
    Swal.fire({
      title: message
    });
    Swal.showLoading();
  }

  public showError(message: string): void {
    Swal.fire({
      text: message,
      icon: 'error',
    });
  }

  public showSucces(message: string): void {
    Swal.fire({
      title: message,
      icon: 'success'
    });
  }

  public closeLoading() {
    Swal.close();
  }

  public showAlert() {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this book!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        Swal.fire(
          'Deleted!',
          'The book has been deleted.',
          'success'
        )
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your book is safe :)',
          'error'
        )
      }
    });
  }
}
