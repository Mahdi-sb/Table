using Create_Table.Models;
using Create_Table.Models.DBcontext;
using Create_Table.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository
{
    public class ShowRepository : Ishow
    {
        AppDBcontext Context;
        public ShowRepository(AppDBcontext dBcontext)
        {
            Context = dBcontext;
        }

        public List<string> AllType(int id)
        {
            var column = Context.Types.Where(x => x.TableId == id).ToList();
            return column.Select(x => x.Field_Name).Distinct().ToList();
        }


        public List<Value> ValueOfTable(int id)
        {
            return Context.Values.Where(x => x.TableId == id).ToList();


        }
    }
}
