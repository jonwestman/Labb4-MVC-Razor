using Labb4_MVC_Razor.Data;
using Labb4_MVC_Razor.Models;
using Labb4_MVC_Razor.Models.ViewModels;
using Labb4_MVC_Razor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labb4_MVC_Razor.Controllers
{
    public class LoanController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly ICustomerRepository _customerRepository;

		public LoanController(ApplicationDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
			_customerRepository = customerRepository;
		}

        // Get
        public async Task<IActionResult> Index() 
        {
            var list = _context.BookLists.Include(b => b.book).Include(b => b.customer).OrderBy(b => b.IsReturned);
            return View(await list.ToListAsync());
        }

        // Create

        public IActionResult Create()
        {
            ViewData["FK_BookId"] = new SelectList(_context.Books, "BookId", "Title");
            ViewData["FK_CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Firstname");
            return View();
        }

        // Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLoan(BookList loanBook)
        {
            await _customerRepository.AddBookLoan(loanBook);
            if (loanBook == null)
            {
                return BadRequest("Could not loan book");
            }
            return RedirectToAction(nameof(Index));
        }

        // Mark as returnerd
        public async Task<IActionResult> MarkReturned(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var success = await _customerRepository.MarkReturned(id);
            if (!success) 
            {
                return BadRequest("Could not mark as returned");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
