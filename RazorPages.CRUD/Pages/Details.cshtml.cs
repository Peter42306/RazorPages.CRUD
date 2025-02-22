using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.CRUD.Model;

namespace RazorPages.CRUD.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly StudentContext _context;

        public DetailsModel(StudentContext context)
        {
            _context = context;
        }

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
            else
            {
                Student = student;
            }

            return Page();
        }
    }
}
