using System.ComponentModel.DataAnnotations;

namespace Create_Table.ViewModel
{
    public class ValueView
    {
        [Required]
        public int TableId { get; set; }
        [Required]
        public string Column { get; set; }
        [Required(ErrorMessage = " وارد شود")]
        public string FieldValue { get; set; }
        public string Type { get; set; }



    }
}
