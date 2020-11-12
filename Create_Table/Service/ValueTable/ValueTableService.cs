using Create_Table.Models;
using Create_Table.Models.DBcontext;
using Create_Table.Repository.AddValue;
using Create_Table.ViewModel;
using System.Collections.Generic;

namespace Create_Table.Service.ValueTable
{
    public class ValueTableService : IValueTableService
    {
        
        public void AddToValueTable(AppDBcontext Context, List<ValueView> values)
        {
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
        }
    }
}
