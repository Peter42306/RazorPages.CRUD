using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.CRUD.Model;

namespace RazorPages.CRUD.Pages
{
	public class IndexModel : PageModel
	{
		private readonly StudentContext _context;

        public IndexModel(StudentContext context)
        {
            _context = context;
        }

		public IList<Student> StudentList { get; set; } = default!;

		public async Task OnGetAsync()
		{
			if (_context.Students!= null)
			{
                StudentList = await _context.Students.ToListAsync();
			}
		}

		public async Task OnGetByAge()
		{
			if (_context.Students!=null)
			{
                StudentList=await _context.Students.OrderBy(s => s.Age).ToListAsync();
			}
		}		
	}
}
