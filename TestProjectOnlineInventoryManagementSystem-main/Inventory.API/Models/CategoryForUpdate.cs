using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Models
{
    public class CategoryForUpdate
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
