using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Create_Table.ViewModel
{
    public class TableView
    {
        [Required(ErrorMessage = "نام جدول وارد شود")]
        [Display(Name ="نام جدول")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "نام جدول نمیتواند شامل اعداد باشد")]

        public string TableName { get; set; }
        
        
        public List<TypeList> TypeList { get { return _TypeList; } }

        private List<TypeList> _TypeList = new List<TypeList>();

    }
    public class TypeList
    {
        public enum Types
        {
            STRING,
            INT,
            BOOL

        }

        [Required]

        public Types Type { get; set; }

        [Required(ErrorMessage = "نام ستون وارد شود")]
       // [RegularExpression(@"[a-zA-Z]" , ErrorMessage ="نام ستون نمیتواند شامل اعداد باشد")]

        public string ColumnName { get; set; }

        public IEnumerable<SelectListItem> TypeSelectListItems
        {
            get
            {
                foreach (Types type in Enum.GetValues(typeof(Types)))
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Text = type.ToString();
                    selectListItem.Value = type.ToString();
                    selectListItem.Selected = Type == type;

                    yield return selectListItem;
                }
            }
        }
    }

}
