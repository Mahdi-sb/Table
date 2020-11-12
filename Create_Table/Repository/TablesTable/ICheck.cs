﻿using Create_Table.Models.DBcontext;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository
{
    interface ICheck
    {
        /// <summary>
        /// show error if have not column yet 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string CheckColumnCount(TableView model);
        /// <summary>
        /// show error if Name of table exixst 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string CheckName( TableView model);
        /// <summary>
        /// show error if column name is repeptive 
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        string CheckColumnName(AppDBcontext Context, TableView model);
        /// <summary>
        /// check all error of page and show 
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        string CheckInput(AppDBcontext Context,TableView model);


    }
}