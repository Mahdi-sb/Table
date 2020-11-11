using Create_Table.Models.DBcontext;
using Create_Table.Repository;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Service
{
    public class Service : IService
    {
        
        public void AddTo_Tables(AppDBcontext Context, TableView model)
        {
            Context.Tables.Add(new Models.Tables { TableName = model.TableName });
            Context.SaveChanges();
        }
        
        public void AddTo_Time(AppDBcontext Context, int Id)
        {
            Context.CreateTimes.Add(new Models.CreateTime
            {
                TableId = Id,
                Time = DateTime.Now
            });

            Context.SaveChanges();
        }
        
        public void AddTo_Type(AppDBcontext Context, TableView model, int Id)
        {
            foreach (var item in model.TypeList)
            {
                Context.Types.Add(new Models.Type
                {
                    Field_Type = item.Type.ToString(),
                    Field_Name = item.ColumnName,
                    TableId = Id
                });
            }
            Context.SaveChanges();
        }
    }
}
