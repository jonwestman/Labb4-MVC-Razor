using Labb4_MVC_Razor.Data;
using Labb4_MVC_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4_MVC_Razor.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ApplicationDbContext _context;

		public CustomerRepository(ApplicationDbContext context)
        {
			_context = context;
		}
        public async Task AddBookLoan(BookList entity)
		{
			entity.ReturnDate = DateTime.Now.AddDays(30);
			entity.IsReturned = false;
			await _context.BookLists.AddAsync(entity);
			await SaveAsync();
		}

		public async Task CreateAsync(Customer entity)
		{
			await _context.AddAsync(entity);
			await SaveAsync();
		}

		public async Task<Customer> FindAsync(int? id)
		{
			return await _context.Customers.FindAsync(id);
		}

		public async Task<List<Customer>> GetAllAsync()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetAsync(int? id)
		{
			return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
		}

		public async Task<bool> MarkReturned(int? id)
		{
			var book = await _context.BookLists
				.Where(b => b.BookListId == id)
				.SingleOrDefaultAsync();
			if (book == null) return false;
			{
				book.IsReturned = true;
				book.DateReturned = DateTime.Now;
			}

			var save = await _context.SaveChangesAsync();
			return save == 1;
		}

		public async Task RemoveAsync(Customer entity)
		{
			_context.Remove(entity);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Customer entity)
		{
			_context.Update(entity);
			await SaveAsync();
		}
	}
}
