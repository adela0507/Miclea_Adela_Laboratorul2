using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Miclea_Adela_Laboratorul2.Data;
using Miclea_Adela_Laboratorul2.Models;

namespace Miclea_Adela_Laboratorul2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Miclea_Adela_Laboratorul2.Data.Miclea_Adela_Laboratorul2Context _context;

        public IndexModel(Miclea_Adela_Laboratorul2.Data.Miclea_Adela_Laboratorul2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Publisher != null)
            {
                Publisher = await _context.Publisher.ToListAsync();
            }
        }
    }
}
