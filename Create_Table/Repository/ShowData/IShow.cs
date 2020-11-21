using Create_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository.ShowData
{
    public interface IShow
    {
        public List<Value> ValueOfTable(int id);
        public List<string> AllType(int id);

    }
}
