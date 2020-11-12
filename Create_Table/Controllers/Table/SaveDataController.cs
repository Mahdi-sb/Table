using System.Collections.Generic;
using System.Linq;
using Create_Table.Models.DBcontext;
using Create_Table.Service.ValueTable;
using Create_Table.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers.Table
{
    public class SaveDataController : Controller
    {

        private readonly AppDBcontext _dBcontext;
        private readonly ValueTableService _service = new ValueTableService();
        private readonly CheckData _check = new CheckData();

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
            List<TypeView> model = new List<TypeView>();
            ////fill viewmodel with corrent  information
            foreach (var item in TableData)
            {
                model.Add(new TypeView
                {
                    Field_Name = item.Field_Name,
                    Field_Type = item.Field_Type,
                    TableId = item.TableId,
                    Value = null

                });

            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SeedData(List<ValueView> values, List<TypeView> model)
        {
            ////fill ViewModel with information
            for (int i = 0; i < values.Count; i++)
            {
                model.Add(new TypeView
                {
                    Field_Type = values[i].Type,
                    Field_Name = values[i].Column,
                    TableId = values[i].TableId
                    ,
                    Value = values[i].FieldValue
                });
            }
            if (ModelState.IsValid)
            {
                if (_check.CheckValues(values) != null)
                {
                    ViewData["ErrorMessage"] = _check.CheckValues(values);
                    return View(model);
                }
                _service.AddToValueTable(_dBcontext, values);
                return RedirectToAction("Index", "Home");
            }
            ViewData["ErrorMessage"] = "فیلد هارا پر کنید";
            return View(model);
        }

    }
}


