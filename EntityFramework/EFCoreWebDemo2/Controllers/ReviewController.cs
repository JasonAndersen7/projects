    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Rendering;
    namespace EFCoreWebDemo.Controllers
    {
        public class ReviewController : Controller
        {
            public async Task<IActionResult> Index()
            {
                using (var context = new EFCoreWebDemoContext())
                {
                    //the code in the Index method retrieves all authors and uses the Include method to eagerly 
                    //load the related books from the database and passes them to the View.
                    var model = await context.Authors.Include(a => a.Books).ThenInclude(r => r.Reviews).AsNoTracking().ToListAsync();
                    return View(model);
                }
                
            }  
            [HttpGet]
            public async Task<IActionResult> Create()
            {
                using(var context = new EFCoreWebDemoContext())
                {

                    //each of the authors are retrieved from the database and projected into a new form - a SelectListItem
                    var authors = await context.Authors.Select(a => new SelectListItem {
                        Value = a.AuthorId.ToString(), 
                        Text = $"{a.FirstName} {a.LastName}"
                    }).ToListAsync();
                    ViewBag.Authors = authors;


                    //each of the books are retrieved from the database and projected into a new form - a SelectListItem
                    var books = await context.Books.Select(a => new SelectListItem {
                        Value = a.BookId.ToString(), 
                        Text = $"{a.Title}"
                    }).ToListAsync();
                    ViewBag.Books = books;
                }
                return View();
            }

            ///The second Create method features an example of the entity being added to its DbSet, rather than the DbContext as was the case for the author.
            [HttpPost]
            public async Task<IActionResult> Create([Bind("Title, AuthorId", "Review")] Review review)
            {
                using (var context = new EFCoreWebDemoContext())
                {
                    context.Reviews.Add(review);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
        }
    }