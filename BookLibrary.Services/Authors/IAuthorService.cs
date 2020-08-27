using BookLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Authors
{
    /// <summary>
    /// Authors service interface
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>Lists of books</returns>
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
    }
}
