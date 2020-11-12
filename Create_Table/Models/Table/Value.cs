using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Models
{
    public class Value
    {
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public string Column { get; set; }
        [Required]
        public string FieldValue { get; set; }
    }
}
