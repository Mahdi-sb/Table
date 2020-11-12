using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository.ValueTable
{
    interface ICheck
    {
        /// <summary>
        /// check field value to not have digit on it
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        string CheckString(List<ValueView> values);
        /// <summary>
        /// check field value to Bool type
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        string CheckBool(List<ValueView> values);
        /// <summary>
        /// check field value to int type
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        string CheckInt(List<ValueView> values);
        /// <summary>
        /// check values is Correct
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        string CheckValues(List<ValueView> values);



    }
}
