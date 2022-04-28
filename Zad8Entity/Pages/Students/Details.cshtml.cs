#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using efcore;
using efcore.Data;

namespace efcore.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly efcore.Data.UniversityContext _context;

        public DetailsModel(efcore.Data.UniversityContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.FirstOrDefaultAsync(m => m.id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
