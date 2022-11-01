﻿using System.ComponentModel.DataAnnotations;

namespace Miclea_Adela_Laboratorul2.Models
{
    public class Author
    {
        public int ID { get; set; }
       
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        public string FullName { get{ return FirstName + "" + LastName; }}
        public ICollection<Book>? Books { get; set; }
    }
}
