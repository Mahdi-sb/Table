using Create_Table.Models.DBcontext;
using Create_Table.Service.CreateTable;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository
{
    public class AddTable :ICreate
    {
        AppDBcontext Context;
       private readonly ICheckInput _Check;

        public AddTable(AppDBcontext dbContext, ICheckInput check)

        {
            _Check = check;
            this.Context = dbContext;
        }
        int GetIdOfTable(string tablename)
        {
            return Context.Tables.Where(x => x.TableName == tablename).Select(x=>x.Id).FirstOrDefault();////get table id 

        }
        public void AddToTables(TableView model)
        {
            Context.Tables.Add(new Models.Tables { TableName = model.TableName });
            Context.SaveChanges();
        }

        public void AddToTime(int Id)
        {
            Context.CreateTimes.Add(new Models.CreateTime
            {
                TableId = Id,
                Time = DateTime.Now
            });

            Context.SaveChanges();
        }

        public void AddToType(TableView model, int Id)
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

        /// <summary>
        /// create table and if have error return error
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddInformationTodatabase(TableView model)
        {
            if (_Check.CheckInput(model) != null) return _Check.CheckInput(model);
            AddToTables(model);
            AddToType(model, GetIdOfTable(model.TableName));
            AddToTime(GetIdOfTable(model.TableName));
            return null;
        }
    }
}
