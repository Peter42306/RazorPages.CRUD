using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.CRUD.Model;

namespace RazorPages.CRUD.Pages
{
    public class EditModel : PageModel
    {
		private readonly StudentContext _context;

		public EditModel(StudentContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Student Student { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Students == null)
			{
				return NotFound();
			}

			var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
			if (student == null)
			{
				return NotFound();
			}
			Student = student;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Student).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentExists(Student.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool StudentExists(int id)
		{
			return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
