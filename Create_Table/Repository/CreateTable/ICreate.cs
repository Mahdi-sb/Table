using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository.CreateTable
{
   public interface ICreate
    {

        /// <summary>
        /// Add Value to Tables Table in Database
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="model"></param>
        void AddToTables(TableView model);
        /// <summary>
        /// Add value to Type Table in Database
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="Id"></param>
        void AddToType(TableView model, int Id);

        /// <summary>
        /// Add value to CreateTime Table in Database
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="model"></param>
        /// <param name="Id"></param>
        void AddToTime(int Id);


        public string AddInformationTodatabase(TableView model);

    }
}
