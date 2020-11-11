using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Models
{
    public class Value
    {
        public int Id { get; set; }

        public int TableId { get; set; }

        public string Column { get; set; }
        public string FieldValue { get; set; }
    }
}
