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
using efcore.Models;
namespace efcore.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly efcore.Data.UniversityContext _context;

        public IndexModel(efcore.Data.UniversityContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
