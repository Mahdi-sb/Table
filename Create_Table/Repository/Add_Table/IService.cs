using Create_Table.Models.DBcontext;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository
{
    interface IService
    {
        /// <summary>
        /// Add Value to Tables Table in Database
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="model"></param>
        void AddTo_Tables(AppDBcontext Context , TableView model);
        /// <summary>
        /// Add value to Type Table in Database
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="Id"></param>
        void AddTo_Type(AppDBcontext Context, TableView model , int Id);

        /// <summary>
        /// Add value to CreateTime Table in Database
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="model"></param>
        /// <param name="Id"></param>
        void AddTo_Time(AppDBcontext Context, int Id);





    }
}
