using BookLibrary.Services.Contracts;
using NUnit.Framework;

namespace BookLibrary.Test
{
    [TestFixture]
    public class BookLibraryServicesTest
    {
        private readonly IBookService _bookService;

        public BookLibraryServicesTest(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void With_Empty_String_Returns_Empty_String()
        {
            var response = _bookService.GetAllBooks();

            Assert.That(response, Is.EqualTo(200));
        }
    }
}
