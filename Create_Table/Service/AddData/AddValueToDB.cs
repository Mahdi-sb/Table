using Create_Table.Models;
using Create_Table.Models.DBcontext;
using Create_Table.Repository.AddData;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = Create_Table.Models.Type;

namespace Create_Table.Service.AddData
{
    public class AddValueToDB :IAddData
    {
        readonly AppDBcontext Context;
        private readonly ICheckValue _check ;

        public AddValueToDB(AppDBcontext dbContext , ICheckValue check)
        {
            Context = dbContext;
            _check = check;
        }

        public List<Type> TableData(int id)
        {
            return Context.Types.Where(x => x.TableId == id).ToList();

        }
        public List<Tables> AllTable()
        {
            return Context.Tables.ToList();

        }

        public string AddToValueTable(List<ValueView> values)
        {
            if (_check.CheckValues(values) != null) return _check.CheckValues(values);
            foreach (var item in values)
            {
                Context.Values.Add(new Value
                {
                    TableId = item.TableId,
                    FieldValue = item.FieldValue.ToLower(),
                    Column = item.Column
                });
            }

            Context.SaveChanges();
            return null;
        }

    }
}
