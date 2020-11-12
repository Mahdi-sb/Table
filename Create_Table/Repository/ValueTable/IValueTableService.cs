using Create_Table.Models.DBcontext;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository.AddValue
{
    interface IValueTableService
    {
        /// <summary>
        /// Add values to Value Table 
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="values"></param>
        void AddToValueTable(AppDBcontext Context,List<ValueView> values);


    }
}
