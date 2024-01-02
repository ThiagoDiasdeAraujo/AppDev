//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApiDemo.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BookController : ControllerBase
//    {
//        private List<Book> _books;

//        public BookController()
//        {
//            _books = new List<Book>()
//            {
//                new Book() { Id = 1, Description = "Book1", Title = "Genre1" },
//                new Book() { Id = 2, Description = "Book1", Title = "Genre1" },
//            };
//        }

//        //[Route("/boeken")]
//        //public ActionResult<IEnumerable<Book>> GetAll()
//        //{

//        //    return Ok(books);
//        //}

//        [Route("{id}")]
//        public ActionResult<Book> Get(int id)
//        {
//            Book book = _books.FirstOrDefault(x => x.Id == id);

//            if (book == null)
//            {
//                return NotFound();
//            }
//            return Ok(book);

//        }

//        [HttpGet]
//        public ActionResult<IEnumerable<Book>> Search(string title, string description)
//        {
//            return _books.Where(x => x.Title == title && x.Description == description).ToList();
//        }
//    }
//}

