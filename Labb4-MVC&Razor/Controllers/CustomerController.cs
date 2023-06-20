using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb4_MVC_Razor.Data;
using Labb4_MVC_Razor.Models;
using Labb4_MVC_Razor.Repositories;

namespace Labb4_MVC_Razor.Controllers
{
    public class CustomerController : Controller
    {
		private readonly ICustomerRepository _context;

		public CustomerController(ICustomerRepository context)
        {
			_context = context;
		}
		// Get searchString
		public async Task<ActionResult> GetCustomer(string searchString)
		{
			IEnumerable<Customer> list = await _context.GetAllAsync();
			if (!String.IsNullOrEmpty(searchString))
			{
				return View("GetCustomer", list.Where(c => c.Lastname!.ToLower().Contains(searchString.ToLower())));
			}

			return View(list);
		}
		// Create
		public IActionResult CreateCustomer() 
		{
			return View();
		}

		// Post Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateCustomer([Bind("CustomerId, Firstname, Lastname, Address, Email, Phone")]Customer customer)
		{
			if (ModelState.IsValid) 
			{
				await _context.CreateAsync(customer);
				return RedirectToAction(nameof(GetCustomer));
			}
			return View(customer);
		}

		// Edit
		public async Task<IActionResult>EditCustomer(int? id)
		{
			if (id == null) 
			{
				return NotFound();
			}
			var customer = await _context.FindAsync(id);
			if (customer == null) 
			{
				return NotFound();
			}
			return View(customer);
		}

		// Post Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditCustomer(int id, [Bind("CustomerId, Firstname, Lastname, Address, Email, Phone")]Customer customer)
		{
			if (id != customer.CustomerId) 
			{
				return NotFound();
			}
			if (ModelState.IsValid) 
			{
				try
				{
					await _context.UpdateAsync(customer);
					await _context.SaveAsync();
				}
				catch (Exception)
				{
					if (customer == null)
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(GetCustomer));
			}
			return View(customer);
		}

		// Delete
		public async Task<IActionResult> DeleteCustomer(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var customer = await _context.GetAsync(id);
			if (customer == null)
			{
				return NotFound();
			}
			return View(customer);
		}

		// Post Delete
		[HttpPost, ActionName("DeleteCustomer")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteMade(int id)
		{
			if (_context==null)
			{
				return NotFound();
			}
			var customer = await _context.FindAsync(id);
			if (customer != null)
			{
				await _context.RemoveAsync(customer);
			}
			return RedirectToAction(nameof(GetCustomer));
		}

    }
}
