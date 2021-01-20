using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Models
{ 
    // [Table("Category")]
    public class Category
    {
        public Guid Id { get; set; }
 
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    } 
}
