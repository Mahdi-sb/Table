using Create_Table.Models.DBcontext;
using Create_Table.Repository;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Service.Add_Table
{
    public class Check : ICheck
    {
        public string CheckColumnName(AppDBcontext Context, TableView model)
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

        public string CheckInput(AppDBcontext Context, TableView model)
        {
            

            if (CheckName(model) != null) return CheckName(model);
            if (CheckColumnCount(model) != null) return CheckColumnCount(model);
            if (CheckColumnName(Context, model) != null) return CheckColumnName(Context,model);
            return null;




        }
    }
}
