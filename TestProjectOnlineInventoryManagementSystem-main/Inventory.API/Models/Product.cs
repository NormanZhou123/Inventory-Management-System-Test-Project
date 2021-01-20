using Inventory.API.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.API.Models
{
    public class Product
    {
        [NotEmpty]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Unit Price")]
        [Column(TypeName = "decimal(18, 2)")]
        [DefaultValue(0.00)]
        public float UnitPrice { get; set; }
    
        public Guid CategoryId { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "Quantity")]
        [DefaultValue(1)]
        public int Quantity{get;set;}
    }
}
