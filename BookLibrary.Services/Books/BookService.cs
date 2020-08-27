using BookLibrary.Core.Models;
using BookLibrary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookLibrary.Services.Books
{
    /// <summary>
    /// Book service class
    /// </summary>
    public class BookService : IBookService
    {
        private readonly string BaseUrl = "https://fakerestapi.azurewebsites.net";
        private HttpResponseMessage response = new HttpResponseMessage();

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>Lists of books</returns>
        public async Task<IList<Book>> GetAllBooks()
        {
            IList<Book> books = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync("api/books");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<IList<Book>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
            }
            return books;
        }

        /// <summary>
        /// Inserts book
        /// </summary>
        /// <param name="book">Book</param>
        public async Task<Book> InsertBook(Book book)
        {
            var values = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                PageCount = book.PageCount,
                Excerpt = book.Excerpt,
                PublishDate = DateTime.Now
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                response = await client.PostAsJsonAsync<Book>("api/books", values);

                if (response.IsSuccessStatusCode)
                {

                    var readTask = response.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    return values;
                }
            }

            return values;

        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="Id">Book identifier</param>
        public async void DeleteBook(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.DeleteAsync(string.Format("api/books/{0}", Id));
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<Book>();
                    readTask.Wait();
                }
            }
        }

        /// <summary>
        /// Updates the book
        /// </summary>
        /// <param name="book">Book</param>
        public async Task<Book> UpdateBook(Book book)
        {
            Book result = await GetBookById(book.Id);

            if (result != null)
            {
                result.Title = book.Title;
                result.Description = book.Description;
                result.PageCount = book.PageCount;
                result.Excerpt = book.Excerpt;
                result.PublishDate = book.PublishDate;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    response = await client.PutAsJsonAsync<Book>("api/books", result);

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsAsync<Book>();
                        readTask.Wait();

                        return result;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get a book
        /// </summary>
        /// <param name="Id">Book identifier</param>
        /// <returns>Book</returns>
        public async Task<Book> GetBookById(int Id)
        {
            Book book = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync(string.Format("api/books/{0}", Id));
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }
            return book;
        }
    }
}
