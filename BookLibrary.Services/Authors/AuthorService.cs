using BookLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly string BaseUrl = "https://fakerestapi.azurewebsites.net";
        private HttpResponseMessage response = new HttpResponseMessage();

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>Lists of books</returns>
        public async Task<IList<Author>> GetAllAuthors()
        {
            IList<Author> authors = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync("api/Authors");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<IList<Author>>();
                    readTask.Wait();

                    authors = readTask.Result;
                }
            }
            return authors;
        }

        /// <summary>
        /// Inserts book
        /// </summary>
        /// <param name="book">Book</param>
        public async Task<Author> InsertAuthor(Author author)
        {
            var values = new Author()
            {
                IdBook = author.IdBook,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                response = await client.PostAsJsonAsync<Author>("api/authors", values);

                if (response.IsSuccessStatusCode)
                {

                    var readTask = response.Content.ReadAsAsync<Author>();
                    readTask.Wait();

                    return values;
                }
            }

            return values;
        }

        /// <summary>
        /// Delete author
        /// </summary>
        /// <param name="Id">Author identifier</param>
        public async void DeleteAuthor(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.DeleteAsync(string.Format("api/authors/{0}", Id));
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<Author>();
                    readTask.Wait();
                }
            }
        }

        /// <summary>
        /// Updates the author
        /// </summary>
        /// <param name="book">author</param>
       public async Task<Author> UpdateAuthor(Author author)
        {
            Author result = await GetAuthorById(author.Id);

            if (result != null)
            {
                result.IdBook = author.IdBook;
                result.FirstName = result.FirstName;
                result.LastName = result.LastName;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                response = await client.PutAsJsonAsync<Author>("api/authors", result);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<Author>();
                    readTask.Wait();

                    return result;
                }
            }


            return result;
        }

        /// <summary>
        /// Get an author
        /// </summary>
        /// <param name="Id">Author identifier</param>
        /// <returns>Author</returns>
        public async Task<Author> GetAuthorById(int Id)
        {
            Author author = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = await client.GetAsync(string.Format("api/authors/{0}", Id));
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<Author>();
                    readTask.Wait();

                    author = readTask.Result;
                }
            }
            return author;
        }
    }
}
