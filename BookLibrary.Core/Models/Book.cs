using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Core.Models
{
    /// <summary>
    /// Represent a book
    /// </summary>
    public sealed class Book
    {
        /// <summary>
        /// Represent the id of the book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represent the title of a book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represent the Description of a book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Represent the pages count of a book
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Represent the excerpt of a book
        /// </summary>
        public string Excerpt { get; set; }

        /// <summary>
        /// Represent the publish data of a book
        /// </summary>
        public DateTime PublishDate { get; set; }
    }
}
