using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Core.Models
{
    /// <summary>
    /// Represent an author
    /// </summary>
    public sealed class Author
    {
        /// <summary>
        /// Represent the id of the author.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represent the id identifier of a book.
        /// </summary>
        public int IdBook { get; set; }

        /// <summary>
        /// Represent the First Name 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represent the Last Name
        /// </summary>
        public string LastName { get; set; }

    }
}
