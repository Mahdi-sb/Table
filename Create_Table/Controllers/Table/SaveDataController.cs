using System.Collections.Generic;
using System.Linq;
using Create_Table.Models.DBcontext;
using Create_Table.Service.AddData;
using Create_Table.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Create_Table.Controllers.Table
{
    public class SaveDataController : Controller
    {
        private readonly IAddData _service;
        public SaveDataController(IAddData service)
        {
            _service = service;
        }

        /// <summary>
        /// create page to show tables and choose to seed data on it
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ChooseTable()
        {
            
            ViewData["Table"] = _service.AllTable();
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
            var TableData = _service.TableData(id);
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
               string error= _service.AddToValueTable(values);
                if (error != null)
                {
                    ViewData["ErrorMessage"] = error;
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            ViewData["ErrorMessage"] = "فیلد هارا پر کنید";
            return View(model);
        }

    }
}


