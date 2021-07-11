    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    namespace EFCoreWebDemo.Controllers
    {
        public class AuthorController : Controller
        {
            public async Task<IActionResult> Index()
            {
                //The DbContext is instantiated in a using block to ensure that it is disposed properly
                using (var context = new EFCoreWebDemoContext())
                {
                    //The AsNoTracking method is used to prevent the context from unnecessarily tracking the data because it is intended for read-only use.
                    var model = await context.Authors.AsNoTracking().ToListAsync();
                    return View(model);
                }
                
            }  
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            /// The Create method that takes an Author as a parameter is responsible for adding the new author to the database. 
            /// It uses the approach whereby data is added directly to the DbContext, allowing the context to infer the type of 
            // data to be added to the database.
            [HttpPost]
            public async Task<IActionResult> Create([Bind("FirstName, LastName")] Author author)
            {
                using (var context = new EFCoreWebDemoContext())
                {
                    context.Add(author);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
        }
    }