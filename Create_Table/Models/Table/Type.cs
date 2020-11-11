using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Models
{
    public class Type
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string Field_Name { get; set; }
        public string Field_Type { get; set; }

    }
}
