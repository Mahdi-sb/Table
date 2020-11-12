using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Create_Table.Models.DBcontext;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers.Table
{
    

    public class ShowController : Controller
    {
        private readonly AppDBcontext _dBcontext;

        public ShowController(AppDBcontext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        /// <summary>
        /// show data of table 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ShowData(int id)
        {
            var info = _dBcontext.Values.Where(x => x.TableId == id).ToList();
            var column= _dBcontext.Types.Where(x => x.TableId == id).ToList();
            ViewData["column"] = column.Select(x => x.Field_Name).Distinct().ToList();
            return View(info);
        }
    }
}
