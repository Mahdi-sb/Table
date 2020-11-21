using Create_Table.Models.DBcontext;
using Create_Table.Repository.CreateTable;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Service.CreateTable
{
    public class CheckValueInput : ICheckInput
    {
        readonly AppDBcontext Context;
        public CheckValueInput(AppDBcontext dbContext)
        {
            Context = dbContext;
        }

        public string CheckColumnName(TableView model)
        {
            var flag = Context.Tables.Where(x => x.TableName == model.TableName).ToList().Count;
            if (flag > 0)
            {
                return " نام جدول موجود میباشد";

            }
            return null;
        }
        public string CheckColumnCount(TableView model)
        {
            var count = model.TypeList.Count;
            if (count == 0)
            {
                return " ستون جدول اضافه کنید";

            }
            return null;
        }

        public string CheckName(TableView model)
        {
            var name = " ";
            foreach (var item in model.TypeList)
            {
                if (item.ColumnName == name)
                {
                    return " نام ستون تکراری  میباشد";


                }
                name = item.ColumnName;
            }

            return null;
        }

        public string CheckInput(TableView model)
        {


            if (CheckName(model) != null) return CheckName(model);
            if (CheckColumnCount(model) != null) return CheckColumnCount(model);
            if (CheckColumnName(model) != null) return CheckColumnName(model);
            return null;




        }
    }
}
