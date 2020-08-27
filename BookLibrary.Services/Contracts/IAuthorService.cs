using BookLibrary.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.Services.Contracts
{
    /// <summary>
    /// Authors service interface
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>Lists of authors</returns>
        Task<IList<Author>> GetAllAuthors();

        /// <summary>
        /// Inserts book
        /// </summary>
        /// <param name="book">Book</param>
        Task<Author> InsertAuthor(Author author);

        /// <summary>
        /// Delete author
        /// </summary>
        /// <param name="Id">Author identifier</param>
        void DeleteAuthor(int Id);

        /// <summary>
        /// Updates the author
        /// </summary>
        /// <param name="book">author</param>
        Task<Author> UpdateAuthor(Author author);

        /// <summary>
        /// Get an author
        /// </summary>
        /// <param name="Id">Author identifier</param>
        /// <returns>Author</returns>
        Task<Author> GetAuthorById(int Id);

        /// <summary>
        /// Get author books
        /// </summary>
        /// <param name="Id">Book identifier</param>
        /// <returns>Lists of books</returns>
        Task<IList<Author>> GetAuthorByIdBook(int IdBook);
    }
}
