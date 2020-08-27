using BookLibrary.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.Services.Contracts
{
    /// <summary>
    /// Book service interface
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>Lists of books</returns>
        Task<IList<Book>> GetAllBooks();

        /// <summary>
        /// Inserts book
        /// </summary>
        /// <param name="book">Book</param>
        Task<Book> InsertBook(Book book);

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="Id">Book identifier</param>
        void DeleteBook(int Id);

        /// <summary>
        /// Updates the book
        /// </summary>
        /// <param name="book">Book</param>
        Task<Book> UpdateBook(Book book);

        /// <summary>
        /// Get a book
        /// </summary>
        /// <param name="Id">Book identifier</param>
        /// <returns>Book</returns>
        Task<Book> GetBookById(int Id);
    }
}
