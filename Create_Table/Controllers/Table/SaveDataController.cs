using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Create_Table.Models;
using Create_Table.Models.DBcontext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers.Table
{
    public class SaveDataController : Controller
    {

        private readonly AppDBcontext _dBcontext;

        public SaveDataController(AppDBcontext dBcontext)
        {
            _dBcontext = dBcontext;
        }
        /// <summary>
        /// create page to show tables and choose to seed data on it
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ChooseTable()
        {
            var Tables = _dBcontext.Tables.ToList();
            ViewData["Table"] = Tables;
            return View();
        }

        /// <summary>
        /// seed data on table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SeedData(int id)
        {
            var TableData = _dBcontext.Types.Where(x => x.TableId == id).ToList();
            ViewData["Data"] = TableData;
            return View();
        }

        [HttpPost]
        public IActionResult SeedData(List<Value> values  )
        {
            return View();
        }

    }
}


