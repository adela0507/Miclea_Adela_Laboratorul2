﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Miclea_Adela_Laboratorul2.Data;
using Miclea_Adela_Laboratorul2.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace Miclea_Adela_Laboratorul2.Pages.Books
{
    [Authorize(Roles="Admin")]
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Miclea_Adela_Laboratorul2.Data.Miclea_Adela_Laboratorul2Context _context;

        public CreateModel(Miclea_Adela_Laboratorul2.Data.Miclea_Adela_Laboratorul2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
           
                       ViewData["AuthorID"] = new SelectList(authorList, "ID",
"FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID",
"PublisherName"); 
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            /*if (!ModelState.IsValid)
              {
                  return Page();
              }

              _context.Book.Add(Book);
              await _context.SaveChangesAsync();

              return RedirectToPage("./Index");
 
            }*/
          var newBook=Book;
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            /*if (await TryUpdateModelAsync<Book>(
            newBook,
            "Book",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }*/
            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
